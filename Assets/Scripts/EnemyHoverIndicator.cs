using UnityEngine;

public class EnemyHoverIndicator : MonoBehaviour
{
    private Renderer enemyRenderer;
    private Color originalColor;
    public Color hoverColor = Color.red; // Highlight color

    void Start()
    {
        enemyRenderer = GetComponent<Renderer>();
        if (enemyRenderer != null)
        {
            originalColor = enemyRenderer.material.color;
        }
    }

    void OnMouseEnter()
    {
        if (enemyRenderer != null)
        {
            enemyRenderer.material.color = hoverColor;
        }
    }

    void OnMouseExit()
    {
        if (enemyRenderer != null)
        {
            enemyRenderer.material.color = originalColor;
        }
    }
}