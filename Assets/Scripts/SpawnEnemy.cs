using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemies;
    public bool canCreate;
    public float spawnTime;
    public float spawnCd;
    public int enemyNum;


    private void Update()
    {
        spawnTime += Time.deltaTime;
        if (canCreate)
        {
            int idx = Random.Range(0, enemies.Length);
            Instantiate(enemies[idx], transform.position, Quaternion.identity);
            canCreate = false;
            enemyNum++;
        }

        if (spawnTime >= spawnCd && enemyNum <= 5)
        {
            canCreate = true;
            spawnTime = 0;
        }
    }
}
