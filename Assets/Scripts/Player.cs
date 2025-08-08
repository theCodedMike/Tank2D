using System;
using UnityEngine;
using UnityEngine.UI;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class Player : MonoBehaviour
{
    [Header("向上")]
    public KeyCode up;
    [Header("向下")]
    public KeyCode down;
    [Header("向左")]
    public KeyCode left;
    [Header("向右")]
    public KeyCode right;
    [Header("开火")]
    public KeyCode fire;

    [Header("移动方向")] public Direction dir;
    [Header("移动速度")] public float moveSpeed;
    [Header("子弹速度")] public float bulletSpeed;
    [Header("子弹")] public GameObject bulletPrefab;
    [Header("生命值")] public Text life1;
    [Header("射击点")] public Transform shootPoint;

    private Animator _anim;


    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // 向上
        if (Input.GetKey(up))
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
        else if (Input.GetKey(down))
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
        else if (Input.GetKey(left))
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
        else if (Input.GetKey(right))
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

        if (Input.GetKeyDown(fire))
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
            life1.text = "0";
        }
    }
}