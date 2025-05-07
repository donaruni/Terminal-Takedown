using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; //reference to players transform to follow     
    public float speed = 2f; //speed of enemy towards player     

    void Update() //called once per frame
    {
        if (player == null) return; //if player is unassigned, do nothing

        Vector3 direction = (player.position - transform.position).normalized; //calculate direction vector from enemy to player, normalised
        transform.position += direction * speed * Time.deltaTime; //moves enemy towards player at specific speed
    }
}
