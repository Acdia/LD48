using UnityEngine;

public class Impact : MonoBehaviour
{

    public float explosionForce = 10f;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float radius = 5f;

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Collided");

        Collider[] nearby = Physics.OverlapSphere(transform.position, radius, layerMask);

        foreach(Collider c in nearby)
        {

            Brick brick = c.GetComponent<Brick>();
            brick.Break(transform.position, explosionForce, radius);
        }
    }
}
