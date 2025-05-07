using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            // Destroy after the animation ends
            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
        }
        else
        {
            Debug.LogWarning("ExplosionEffect: Animator not found! Using default delay.");
            Destroy(gameObject, 2f); // Default delay
        }
    }
}