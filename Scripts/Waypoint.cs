using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    protected float debugDrawRadius = 1.0f;

    public virtual void onDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, debugDrawRadius);
    }
}