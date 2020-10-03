using UnityEngine;

public class MainMovement : MonoBehaviour
{

    [SerializeField] float movSpeed = 200f;
    [SerializeField] float rotSpeed = 10f;
    [SerializeField] float stopFactor = 0.95f;
    public float mouseSens = 1f;

    [Space]

    [SerializeField] bool enableJumping = false;
    [SerializeField] float jumpForce = 100f;
    [SerializeField] LayerMask gndLayer;
    [SerializeField] float gravityAdder = 100f;

    [SerializeField] Transform cam;
    [SerializeField] Transform gndCheck;

    Rigidbody rb;

    float camRot;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        //Cam Stuff
        float x = Input.GetAxis("Mouse X") * rotSpeed * mouseSens * Time.deltaTime;
        float y = -Input.GetAxis("Mouse Y") * rotSpeed * mouseSens * Time.deltaTime;

        transform.Rotate(0f, x, 0f);

        camRot += y;
        camRot = Mathf.Clamp(camRot, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(camRot, 0f, 0f);

        //Jumping
        if (Input.GetButtonDown("Jump") && enableJumping && Physics.CheckSphere(gndCheck.position, 0.3f, gndLayer))
        {

            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    void FixedUpdate()
    {

        float x = Input.GetAxis("Horizontal") * movSpeed * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * movSpeed * Time.deltaTime;

        rb.AddRelativeForce(x, -gravityAdder * Time.deltaTime, y, ForceMode.VelocityChange);

        if(x == 0 && y == 0)
        {

            rb.velocity *= stopFactor;
        }
        
    }
}
