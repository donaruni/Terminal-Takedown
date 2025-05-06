using UnityEngine;

// Script to destroy explosion GameObject after the animation ends
public class ExplosionEffect : MonoBehaviour
{
    public float destroyDelay = 12f; // Length of the animation

    void Start()
    {
        
        Destroy(gameObject, destroyDelay);
    }
}