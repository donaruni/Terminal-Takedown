using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab; //enemy prefab to be spawned
    public Transform player; //reference to players transform
    public float spawnRadius = 0.5f; //radius around player where enemies spawn
    public float spawnInterval = 0.5f; //interval between enemy spawns

    private float timer; //time keeps track of spawn times

    void Update() //called once per frame
    {
        timer += Time.deltaTime; //increments time with time passed since last frame

        if (timer >= spawnInterval) //when enough time passes, spawns a new enemy
        {
            SpawnEnemies(); //spawns enemy around player
            timer = 0f; //resets the timer
        }
    }

    void SpawnEnemies() //spawns enemy at random position around player within radius
    {
        if (player == null) return; //do nothing if player is unasssigned

        Vector2 offset = Random.insideUnitCircle.normalized * spawnRadius; //generates a random direction within the circle, normalises and scales by spawn radius
        Vector3 spawnPos = player.position + new Vector3(offset.x, offset.y, 0f); //calculates spawn position relative to players

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity); //spawn the enemy at calculated positon, without rotation
    }
}
