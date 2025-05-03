using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Vector2 lastPosition;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
    }
    
    void LateUpdate() // Using LateUpdate to run after movement is applied
    {
        Vector2 currentPosition = transform.position;
        Vector2 movement = currentPosition - lastPosition;
        
        // Only update if we've moved significantly
        if (movement.magnitude > 0.01f)
        {
            // Determine primary direction (up, down, left, right)
            float absX = Mathf.Abs(movement.x);
            float absY = Mathf.Abs(movement.y);
            
            // Set animator parameters directly
            if (absX > absY)
            {
                // Horizontal movement is dominant
                animator.SetFloat("MoveX", movement.x > 0 ? 1 : -1);
                animator.SetFloat("MoveY", 0);
                animator.SetFloat("LastX", movement.x > 0 ? 1 : -1);
                animator.SetFloat("LastY", 0);
            }
            else
            {
                // Vertical movement is dominant
                animator.SetFloat("MoveX", 0);
                animator.SetFloat("MoveY", movement.y > 0 ? 1 : -1);
                animator.SetFloat("LastX", 0);
                animator.SetFloat("LastY", movement.y > 0 ? 1 : -1);
            }
            
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
        
        lastPosition = currentPosition;
    }
}