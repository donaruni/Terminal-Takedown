using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform player;
    public float shootInterval = 2f;

    private float shootTimer;

    void Update()
    {
        if (player == null) return;

        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            ShootAtPlayer();
            shootTimer = 0f;
        }
    }

    void ShootAtPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        bullet.transform.right = -direction;

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetDirection(direction);
        }
    }
}
