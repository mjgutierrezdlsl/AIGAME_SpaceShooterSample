using UnityEngine;

public class ForceField : MonoBehaviour
{
    [SerializeField] float radius = 1f;
    private void FixedUpdate()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                var collider = colliders[i];
                if (collider.CompareTag("Bullet"))
                {
                    Destroy(collider.transform.gameObject);
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}