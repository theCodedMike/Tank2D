using UnityEngine;

public class Basement : MonoBehaviour
{
    public GameObject gameOverPrefab;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("bullet"))
        {
            Destroy(transform.parent.gameObject);
            Instantiate(gameOverPrefab, new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
