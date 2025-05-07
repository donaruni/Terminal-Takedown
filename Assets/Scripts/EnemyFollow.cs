using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; //reference to players transform to follow     
    public float speed = 2f; //speed of enemy towards player     

    private Animator _animator; //reference to animator component
    private const string _horizontal = "Horizontal"; //horizontak parameter string
    private const string _vertical = "Vertical"; //vertical parameter string

    private void Awake() //called once during script loading
    {
        _animator = GetComponent<Animator>(); //assigns animator component to enemy object
    }

    void Update() //called once per frame
    {
        if (player == null) return; //if player is unassigned, do nothing

        Vector3 direction = (player.position - transform.position).normalized; //calculate direction vector from enemy to player, normalised
        transform.position += direction * speed * Time.deltaTime; //moves enemy towards player at specific speed

        _animator.SetFloat(_horizontal, direction.x); //updates horizontal parameter based on direction
        _animator.SetFloat(_vertical, direction.y); //updates vertical parameter based on direction
    }
}
