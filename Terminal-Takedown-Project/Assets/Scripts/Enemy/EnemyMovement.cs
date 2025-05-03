using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    public float moveSpeed;
    
    void Start(){
        player = FindFirstObjectByType<PlayerMovement>().transform;
    }
    
    void Update(){
        // Only move if not extremely close to player
        if (Vector2.Distance(transform.position, player.position) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }
}