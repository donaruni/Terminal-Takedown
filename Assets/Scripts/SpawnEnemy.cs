using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnRadius = 0.5f;
    public float spawnInterval = 0.5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemies();
            timer = 0f;
        }
    }

    void SpawnEnemies()
    {
        if (player == null) return;

        Vector2 offset = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPos = player.position + new Vector3(offset.x, offset.y, 0f);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
