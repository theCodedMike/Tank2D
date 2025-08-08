using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void Start()
    {
        Destroy(gameObject, 2.5f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("bullet") || other.transform.CompareTag("brick") || 
            other.transform.CompareTag("wall") || other.transform.CompareTag("basement"))
        {
            Destroy(gameObject);
        }
    }
}
