using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    [SerializeField] private float _moveSpeed = 5f; //easy to set the movement speed in the inspector of the player object

    private Vector2 _movement; //stores the direction of the players movement
    private Rigidbody2D _rb; //physics based movement
    private Animator _animator; //player animations here
    //these animation parameters are to track the direction of the player
    private const string _horizontal = "Horizontal"; 
    private const string _vertical = "Vertical";
    private const string _lastVertical = "LastVertical";
    private const string _lastHorizontal = "LastHorizontal";

    private void Awake() //script being loaded
    {
        _rb = GetComponent<Rigidbody2D>(); //retrieves and stores the reference for rigid body 2d
        _animator = GetComponent<Animator>(); //retrieves and stores the reference for the animator
    }

    private void Update()
    {
        _movement.Set(InputManager.Movement.x, InputManager.Movement.y); //reads the players movement from the input manager
        _rb.linearVelocity = _movement * _moveSpeed; //applies velocity to the rigid body

        _animator.SetFloat(_horizontal, _movement.x); //called to update the animator based on the players movement direction
        _animator.SetFloat(_vertical, _movement.y); // " "

        if (_movement != Vector2.zero) //if the player is moving it updates the last direction moved.
        {
            _animator.SetFloat(_lastHorizontal, _movement.x);
            _animator.SetFloat(_lastVertical, _movement.y);
        }
    }

    public void Die()
    {
        this.enabled = false; //disables to stop the player movement input

        _rb.linearVelocity = Vector2.zero; //stops the player

        if (MusicManager.Instance != null) //if the music manager is existing, then play the game over screen music
        {
            MusicManager.Instance.PlayDeathMusic();
        }
    }
}
