using Sirenix.OdinInspector;
using UnityEngine;

public sealed class RaycastRotatePoint : MonoBehaviour
{
    [SerializeField, MinValue(10.0f )]
    private float _distanceRaycast;

    private static RaycastHit _hit;
    public static RaycastHit RayHit => _hit;


    void FixedUpdate()
    {
        Ray raycast = new Ray(transform.position, transform.forward);
        _hit = new RaycastHit();

        if (Physics.Raycast(ray: raycast, hitInfo: out _hit, maxDistance: _distanceRaycast))
        {
            Debug.Log(_hit.collider.name);
        }
    }
}
