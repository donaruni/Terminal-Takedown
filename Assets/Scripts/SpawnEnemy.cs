using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    [Tooltip("Prefab of the enemy to spawn.")]
    public GameObject enemyPrefab;

    [Tooltip("The player transform. Enemies will spawn around the player.")]
    public Transform player;

    [Tooltip("Radius around the player where enemies spawn.")]
    public float spawnRadius = 0.5f;

    [Tooltip("Interval (in seconds) between enemy spawns.")]
    public float spawnInterval = 0.5f;

    [Header("Sound Settings")]
    [Tooltip("Sound effect to play when an enemy spawns.")]
    public AudioClip spawnSound;

    [Tooltip("Maximum volume for the spawn sound.")]
    public float maxVolume = 1.0f;

    [Tooltip("Maximum distance for the spawn sound to be heard.")]
    public float maxDistance = 10.0f;

    [Tooltip("Number of sound objects to pre-pool for efficiency.")]
    public int soundPoolSize = 5;

    private float timer;
    private GameObject[] soundPool;
    private int soundPoolIndex = 0;

    void Start()
    {
        InitializeSoundPool();
    }

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
        if (!ValidateReferences())
        {
            return;
        }

        // Determine random spawn position around the player.
        Vector2 offset = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPos = player.position + new Vector3(offset.x, offset.y, 0f);

        // Spawn the enemy.
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        // Play the spawn sound.
        PlaySpawnSound(spawnPos);
    }

    private bool ValidateReferences()
    {
        if (player == null || enemyPrefab == null || spawnSound == null)
        {
            return false;
        }

        return true;
    }

    private void InitializeSoundPool()
    {
        soundPool = new GameObject[soundPoolSize];

        for (int i = 0; i < soundPoolSize; i++)
        {
            GameObject soundObject = new GameObject($"SpawnSound_{i}");
            AudioSource audioSource = soundObject.AddComponent<AudioSource>();
            audioSource.spatialBlend = 0.0f; // 2D sound.
            soundObject.SetActive(false);
            soundPool[i] = soundObject;
        }
    }

    private void PlaySpawnSound(Vector3 spawnPos)
    {
        GameObject soundObject = soundPool[soundPoolIndex];
        soundPoolIndex = (soundPoolIndex + 1) % soundPoolSize;

        soundObject.transform.position = spawnPos;
        soundObject.SetActive(true);

        AudioSource audioSource = soundObject.GetComponent<AudioSource>();

        // Calculate the distance between the spawn position and the player.
        float distance = Vector3.Distance(spawnPos, player.position);

        // Adjust volume based on the distance.
        audioSource.volume = Mathf.Clamp01(1.0f - (distance / maxDistance)) * maxVolume;

        // Configure the AudioSource and play the sound.
        audioSource.clip = spawnSound;
        audioSource.Play();

        // Deactivate the sound object after the clip finishes playing.
        StartCoroutine(DeactivateSoundObject(soundObject, spawnSound.length));
    }

    private System.Collections.IEnumerator DeactivateSoundObject(GameObject soundObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        soundObject.SetActive(false);
    }
}