using UnityEngine;

public class Impact : MonoBehaviour
{

    public float explosionForce = 10f;
    [SerializeField] LayerMask bricks;
    [SerializeField] LayerMask staticWalls;
    [SerializeField] float radius = 5f;

    [Space]

    [SerializeField] GameObject effect;

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Collided");

        effect.SetActive(true);

        Collider[] nearbyStaticWalls = Physics.OverlapSphere(transform.position, radius, staticWalls);

        foreach(Collider c in nearbyStaticWalls)
        {

            c.GetComponent<WallExchanger>().ExchangeWall();
        }

        Collider[] nearbyBricks = Physics.OverlapSphere(transform.position, radius, bricks);

        foreach(Collider c in nearbyBricks)
        {

            Brick brick = c.GetComponent<Brick>();
            brick.Break(transform.position, explosionForce, radius);
        }

        
    }
}
