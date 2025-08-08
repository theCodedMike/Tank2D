using UnityEngine;

public class Brick : MonoBehaviour
{
    private int _shoot;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("bullet"))
        {
            if (_shoot == 2)
            {
                Destroy(transform.parent.gameObject);
                return;
            }

            _shoot++;
        }
    }
}
