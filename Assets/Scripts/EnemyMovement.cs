using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public EnemyData enemyData; // Reference to the enemy data

    private float zigzagOffset; // For zigzag movement
    private float initialX; // To store the initial horizontal position
    private float zigzagWidth = 5f; // Width of the zigzag range
    private float followDelay; // Delay for following the previous enemy

    private void Start()
    {
        zigzagOffset = 0f; // Initialize zigzag offset

        // Store the initial X position
        initialX = transform.position.x;

        // Calculate follow delay based on enemy's index or number of enemies
        int enemyIndex = transform.GetSiblingIndex(); // Get the index of this enemy
        followDelay = enemyIndex * 0.2f; // Adjust the multiplier as needed (0.2f is example delay)

        // Start the movement coroutine
        StartCoroutine(MoveEnemies());
    }

    private IEnumerator MoveEnemies()
    {
        // Wait for the follow delay
        yield return new WaitForSeconds(followDelay);

        while (true)
        {
            switch (enemyData.movementType)
            {
                case EnemyData.MovementType.Straight:
                    MoveStraight();
                    break;
                case EnemyData.MovementType.Zigzag:
                    MoveZigzag();
                    break;
                case EnemyData.MovementType.Wave:
                    MoveWave();
                    break;
                case EnemyData.MovementType.Diagonal:
                    MoveDiagonal();
                    break;
            }

            if (transform.position.y < -Camera.main.orthographicSize)
            {
                Destroy(gameObject); 
            }

            yield return null; 
        }
    }

    private void MoveStraight()
    {
        transform.Translate(Vector2.down * enemyData.moveSpeed * Time.deltaTime);
    }

    private void MoveZigzag()
    {
        zigzagOffset += Time.deltaTime * enemyData.moveSpeed; 

        float zigzagX = Mathf.Sin(zigzagOffset * 2) * (zigzagWidth / 2); 

        float newX = initialX + zigzagX;

        newX = Mathf.Clamp(newX, initialX - zigzagWidth, initialX + zigzagWidth);

        transform.position = new Vector3(newX, transform.position.y - enemyData.moveSpeed * Time.deltaTime, transform.position.z);
    }

    private void MoveWave()
    {
        zigzagOffset += Time.deltaTime * enemyData.moveSpeed;

        float waveX = Mathf.Sin(zigzagOffset) * 0.2f; 

        transform.Translate(new Vector2(waveX, -enemyData.moveSpeed * Time.deltaTime));
    }

    private void MoveDiagonal()
    {
        transform.Translate(new Vector2(-0.5f * enemyData.moveSpeed * Time.deltaTime, -enemyData.moveSpeed * Time.deltaTime));
    }
}
