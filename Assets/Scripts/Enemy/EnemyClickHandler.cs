using UnityEngine;

public class EnemyClickHandler : MonoBehaviour
{
    public TerminalUIHandler terminalUIHandler; // Reference to the TerminalUIHandler script

    private void OnMouseDown()
    {
        // Open the terminal when the enemy is clicked
        if (terminalUIHandler != null)
        {
            terminalUIHandler.OpenTerminal(this.gameObject);
        }
        else
        {
            Debug.LogError("TerminalUIHandler is not assigned to this enemy!");
        }
    }
}