using UnityEngine;

public class MainMovement : MonoBehaviour
{

    [Range(0f, 20f)]
    [SerializeField] float maxSpeed = 3f;
    [Range(0f, 8f)]
    [SerializeField] float mainAcceleration = 1f;

    [Space]

    [Range(50f, 300f)]
    [SerializeField] float steerSens = 100f;
    [Range(50f, 300f)]
    [SerializeField] float rollSens = 100f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Steer();
    }

    void FixedUpdate()
    {

        Accelarate();
    }

    private void Steer()
    {

        Vector2 rot = new Vector2(Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical"));
        rot *= steerSens * Time.deltaTime;

        float roll = -Input.GetAxis("Roll") * rollSens * Time.deltaTime;

        transform.Rotate(rot.y, rot.x, roll);
    }

    private void Accelarate()
    {
        float forwardSpeed = transform.InverseTransformDirection(rb.velocity).z;

        float acceleration = maxSpeed - forwardSpeed;
        if (acceleration < 0f) acceleration = 0f;

        rb.AddRelativeForce(Vector3.forward * acceleration * mainAcceleration);
    }
}
