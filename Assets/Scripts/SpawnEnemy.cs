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
    if (enemyPrefab == null)
    {
        Debug.LogWarning("Enemy prefab is null during Update!");
    }

    if (player == null)
    {
        Debug.LogWarning("Player is null during Update!");
    }

    timer += Time.deltaTime;

    if (timer >= spawnInterval)
    {
        SpawnEnemies();
        timer = 0f;
    }
}

    void SpawnEnemies()
{
    if (player == null)
    {
        Debug.LogError("Player is not assigned in SpawnEnemy!");
        return;
    }

    if (enemyPrefab == null)
    {
        Debug.LogError("Enemy Prefab is not assigned in SpawnEnemy!");
        return;
    }

    Vector2 offset = Random.insideUnitCircle.normalized * spawnRadius;
    Vector3 spawnPos = player.position + new Vector3(offset.x, offset.y, 0f);

    Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
}
}
