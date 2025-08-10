using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [Header("巡逻时间")]
    public float patrolTime;
    [Header("巡逻间隔")]
    public float patrolCd;
    [Header("攻击时间")]
    public float attackTime;
    [Header("攻击间隔")]
    public float attackCd;
    [Header("移动速度")]
    public float moveSpeed;
    [Header("子弹速度")]
    public float bulletSpeed;
    [Header("生命")]
    public int life;
    [Header("是否红色")]
    public bool isRed;
    [Header("道具")]
    public GameObject[] props;
    [Header("方向")]
    public Direction dir = Direction.Up;
    [Header("子弹")]
    public GameObject bulletPrefab;
    [Header("射击点")]
    public Transform shootPoint;

    private Animator _animator;
    private Rigidbody2D _rb;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        patrolTime += Time.deltaTime;
        attackTime += Time.deltaTime;
        if (patrolTime >= patrolCd)
        {
            patrolTime = 0;
            Move();
        }

        if (attackTime >= attackCd)
        {
            attackTime = 0;
            Fire();
        }
    }

    private void Move()
    {
        int randomNum = Random.Range(0, 4);
        // 向上
        if (randomNum == 0)
        {
            switch (dir)
            {
                case Direction.Down: RotatePlayerZ(180); break;
                case Direction.Left: RotatePlayerZ(270); break;
                case Direction.Right: RotatePlayerZ(90); break;
            }

            EnemyMove(Vector2.up);
            dir = Direction.Up;
        }
        // 向下
        else if (randomNum == 1)
        {
            switch (dir)
            {
                case Direction.Up: RotatePlayerZ(180); break;
                case Direction.Left: RotatePlayerZ(90); break;
                case Direction.Right: RotatePlayerZ(270); break;
            }

            EnemyMove(Vector2.down);
            dir = Direction.Down;
        }
        // 向左
        else if (randomNum == 2)
        {
            switch (dir)
            {
                case Direction.Up: RotatePlayerZ(90); break;
                case Direction.Down: RotatePlayerZ(270); break;
                case Direction.Right: RotatePlayerZ(180); break;
            }

            EnemyMove(Vector2.left);
            dir = Direction.Left;
        }
        // 向右
        else if (randomNum == 3)
        {
            switch (dir)
            {
                case Direction.Up: RotatePlayerZ(270); break;
                case Direction.Down: RotatePlayerZ(90); break;
                case Direction.Left: RotatePlayerZ(180); break;
            }

            EnemyMove(Vector2.right);
            dir = Direction.Right;
        }
    }

    private void EnemyMove(Vector2 speedDir)
    {
        _rb.linearVelocity = speedDir * (moveSpeed * Time.deltaTime);
    }
    // 绕Z轴旋转
    private void RotatePlayerZ(float angle)
    {
        transform.Rotate(0, 0, angle);
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
            if (other.gameObject.name.StartsWith("Player"))
            {
                life--;
                if (life == 0)
                {
                    if (isRed)
                    {
                        Instantiate(props[0], transform.position, Quaternion.identity);
                    }
                    _animator.Play("explode");
                    SpawnEnemy.Total--;
                    Destroy(gameObject, 0.25f);
                }
            }
            
            Destroy(other.gameObject);
        }
    }
}
