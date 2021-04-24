using UnityEngine;

public class Brick : MonoBehaviour
{

    public void Break(Vector3 explosionPos, float explosionForce, float radius)
    {

        transform.localScale *= 0.95f;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddExplosionForce(explosionForce, explosionPos, radius);
    }
}
