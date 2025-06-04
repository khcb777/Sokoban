using UnityEngine;

public class Target : MonoBehaviour
{
    public bool HasBox()
    {
        Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Box")) return true;
        }
        return false;
    }
}