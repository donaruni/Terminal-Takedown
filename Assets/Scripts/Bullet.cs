using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f; //bullet travel speed
    private Vector3 direction; //bullet direction

    public void SetDirection(Vector3 dir) //method sets direction for bullet
    {
        direction = dir.normalized; //normalises to ensure consistent speed
    }

    void Update() //this is called once per frame
    {
        transform.position += direction * speed * Time.deltaTime; //moves bullet in specific direction at set speed
    }

    void OnTriggerEnter2D(Collider2D other) //called when bullet collides with another collider (player)
    {
        if (other.CompareTag("Player")) //checks if object tagged player is hit
        {
            HealthManager health = other.GetComponent<HealthManager>(); //gets the health manager component
            if (health != null)
            {
                health.TakeDamage(10); //player takes 10 damage
            }

            Destroy(gameObject); //destroys bullet after player is hit
        }
    }
}
