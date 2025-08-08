using System;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    [Header("移动方向")] public Direction dir;
    [Header("Player2移动速度")] public float moveSpeed;
    [Header("子弹速度")] public float bulletSpeed;
    [Header("子弹")] public GameObject bulletPrefab;
    [Header("生命值")] public Text life2;
    [Header("射击点")] public Transform shootPoint;

    private Animator _anim;


    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // 向上
        if (Input.GetKey(KeyCode.UpArrow))
        {
            switch (dir)
            {
                case Direction.Down: RotatePlayerZ(180); break;
                case Direction.Left: RotatePlayerZ(270); break;
                case Direction.Right: RotatePlayerZ(90); break;
            }

            PlayerMove(0, 0.01f);
            dir = Direction.Up;
        }
        // 向下
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            switch (dir)
            {
                case Direction.Up: RotatePlayerZ(180); break;
                case Direction.Left: RotatePlayerZ(90); break;
                case Direction.Right: RotatePlayerZ(270); break;
            }

            PlayerMove(0, -0.01f);
            dir = Direction.Down;
        }
        // 向左
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            switch (dir)
            {
                case Direction.Up: RotatePlayerZ(90); break;
                case Direction.Down: RotatePlayerZ(270); break;
                case Direction.Right: RotatePlayerZ(180); break;
            }

            PlayerMove(-0.01f, 0);
            dir = Direction.Left;
        }
        // 向右
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            switch (dir)
            {
                case Direction.Up: RotatePlayerZ(270); break;
                case Direction.Down: RotatePlayerZ(90); break;
                case Direction.Left: RotatePlayerZ(180); break;
            }

            PlayerMove(0.01f, 0);
            dir = Direction.Right;
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Fire();
        }
    }

    // 绕Z轴旋转
    private void RotatePlayerZ(float angle)
    {
        transform.Rotate(0, 0, angle);
    }

    // 移动
    private void PlayerMove(float x, float y)
    {
        Vector3 currPos = transform.position;
        currPos += new Vector3(x, y, 0) * moveSpeed;
        transform.position = currPos;
    }

    private void Fire()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        bulletObj.GetComponent<Rigidbody2D>().linearVelocity = bulletSpeed * GetVelocityDirection();
    }

    private Vector2 GetVelocityDirection() => dir switch
    {
        Direction.Up => Vector2.up,
        Direction.Down => Vector2.down,
        Direction.Left => Vector2.left,
        Direction.Right => Vector2.right,
        _ => throw new ArgumentException($"未知方向{dir}")
    };


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("bullet"))
        {
            _anim.Play("explode");
            Destroy(gameObject, 0.25f);
            Destroy(other.gameObject);
            life2.text = "0";
        }
    }
}
