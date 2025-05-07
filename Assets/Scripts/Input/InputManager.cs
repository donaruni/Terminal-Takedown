using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem; //for handling player input


public class InputManager : MonoBehaviour
{
    public static Vector2 Movement; //this stores the current movement input
    private PlayerInput _playerInput; //reference to the playerinput component which handles the unity input system
    private InputAction _moveAction; //references the movement in specific

    private void Awake() //script loaded
    {
        _playerInput = GetComponent<PlayerInput>(); //retrieves the playerinput component that is attached to the object
        _moveAction = _playerInput.actions["Move"]; //retrieves the move action from the action map in the player \input
    }

    private void Update()
    {
        Movement = _moveAction.ReadValue<Vector2>(); //reads the movement vector input from the move action which is the current
    }

}
