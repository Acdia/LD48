using UnityEngine;

public class Impact : MonoBehaviour
{

    public float explosionForce = 10f;
    [SerializeField] LayerMask bricks;
    [SerializeField] LayerMask staticWalls;
    [SerializeField] float radius = 5f;
    [SerializeField] bool isPlayer = true;

    [Space]

    [SerializeField] GameObject effect;

    Vector3 savePos;
    Quaternion saveRot;
    Rigidbody rb;
    MainMovement movement;

    private void Start()
    {

        savePos = transform.position;
        saveRot = transform.rotation;

        rb = GetComponent<Rigidbody>();
        movement = GetComponent<MainMovement>();
    }

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

        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");

        if(isPlayer)
        {

            gm.GetComponent<GameManager>().Die(this);
            movement.enabled = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        
    }

    public void ResetFlight()
    {

        transform.position = savePos;
        transform.rotation = saveRot;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        movement.enabled = true;
    }
}
