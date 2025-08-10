using UnityEngine;

public class PlayerBulletSpeed : MonoBehaviour
{
    [Header("加速")]
    public float speed;
    
    
    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player") || other.transform.CompareTag("Player2"))
        {
            // 改变子弹速度 Order in Layer要在同一层
            other.transform.GetComponent<Player>().bulletSpeed = speed;
        }
    }
}
