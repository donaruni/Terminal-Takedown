using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject bulletObj; //instantiates bullet object
    public Transform player; //reference to players transform to aim at
    public float shootInterval = 2f; //time interval between shots

    private float shootTimer; //timer tracks next shot

    void Update() //called once per frame
    {
        if (player == null) return; //if there is no player to shoot at, do nothing

        shootTimer += Time.deltaTime; //accumulate time

        if (shootTimer >= shootInterval) //if enough time has passed, shoot at player
        {
            ShootAtPlayer(); //fires a bullet at player
            shootTimer = 0f; //resets timer
        }
    }

    void ShootAtPlayer() //fires a bullet in the direction of the player
    {
        Vector3 direction = (player.position - transform.position).normalized; //calculates direction vector towards the player
        GameObject bullet = Instantiate(bulletObj, transform.position, Quaternion.identity); //create the bullet at current enemy position without rotation

        bullet.transform.right = -direction; //rotates the bullet so the tip faces the player (visuals)

        Bullet bulletScript = bullet.GetComponent<Bullet>(); //gets bullet script component from bullet instance
        if (bulletScript != null)
        {
            bulletScript.SetDirection(direction); //sets direction so bullet moves correctly
        }
    }
}
