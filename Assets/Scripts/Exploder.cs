using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explodeRadius = 5f;
    [SerializeField] private float _explodeForce = 100f;

    private readonly float _maxForce = 1000f;
    private readonly float _maxRadius = 50f;

    public void Explode(List<Rigidbody> explodableRigidbodies)
    {
        foreach (Rigidbody explodableRigidbody in explodableRigidbodies)
        {
            if (explodableRigidbody != null)
            {
                Vector3 explosionDirection = (explodableRigidbody.transform.position - transform.position).normalized;

                explodableRigidbody.AddForce(explosionDirection * _explodeForce, ForceMode.Impulse);
            }
        }
    }

    public void Explode(Cube cube)
    {
        _explodeForce = _maxForce / Mathf.Sqrt(cube.transform.localScale.x);
        _explodeRadius = _maxRadius / Mathf.Sqrt(cube.transform.localScale.x);

        Collider[] explodableColliders = Physics.OverlapSphere(cube.transform.position, _explodeRadius);

        foreach (Collider explodeHit in explodableColliders)
            if (explodeHit.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(_explodeForce, cube.transform.position, _explodeRadius);
    }
}
