using UnityEngine;

public class MainMovement : MonoBehaviour
{

    [Range(0f, 20f)]
    [SerializeField] float maxSpeed = 3f;
    [Range(0f, 8f)]
    [SerializeField] float mainAcceleration = 1f;

    [Space]

    [Range(0f, 200f)]
    [SerializeField] float steerSens = 100f;
    [Range(0f, 10f)]
    [SerializeField] float rollSens = 2f;
    public float autoRollForce = 0.1f;
    public bool autoRoll = false;

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

        float roll;

        if (autoRoll)
        {

            float currentRoll = transform.localRotation.eulerAngles.z % 90f;
            if(currentRoll > 45f)
            {

                currentRoll -= 90f;
            }

            roll = -currentRoll * autoRollForce * Time.deltaTime;
            Debug.Log(currentRoll);
        }
        else
        {

            roll = -Input.GetAxis("Roll") * rollSens * Time.deltaTime;
        }


        //transform.Rotate(rot.y, rot.x, roll);
        rb.AddRelativeTorque(rot.y, rot.x, roll);
    }

    private void Accelarate()
    {
        float forwardSpeed = transform.InverseTransformDirection(rb.velocity).z;

        float acceleration = maxSpeed - forwardSpeed;
        if (acceleration < 0f) acceleration = 0f;

        rb.AddRelativeForce(Vector3.forward * acceleration * mainAcceleration);
    }
}
