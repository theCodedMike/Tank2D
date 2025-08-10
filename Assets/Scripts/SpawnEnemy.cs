using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPositions;
    public bool canCreate;
    public float spawnTime;
    public float spawnCd;
    public int enemyNum;
    public Text enemyCount;

    public static int Total;

    private void Update()
    {
        spawnTime += Time.deltaTime;
        if (canCreate)
        {
            int idx = Random.Range(0, enemies.Length);
            Instantiate(enemies[idx], spawnPositions[Random.Range(0, spawnPositions.Length)].position, Quaternion.identity);
            canCreate = false;
            enemyNum++;
            Total++;
            enemyCount.text = $"{Total}";
        }

        if (spawnTime >= spawnCd && enemyNum <= 5)
        {
            canCreate = true;
            spawnTime = 0;
        }
    }
}
