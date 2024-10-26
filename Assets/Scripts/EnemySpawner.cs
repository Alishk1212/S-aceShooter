using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public EnemyData enemyData; 

    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        float startY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y + 1f; // Off-screen above

        for (int i = 0; i < enemyData.numberOfEnemies; i++)
        {
            float spawnX = transform.position.x + (i * enemyData.spacing);
            Vector3 spawnPosition = new Vector3(0, startY, 0);

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
