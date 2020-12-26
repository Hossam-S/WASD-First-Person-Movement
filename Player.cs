using UnityEngine;

public class Player : MonoBehaviour
{

    // This are variables public variables are seen in the inspector and private variables are only seen in the script!
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody RBCOMP;
    public float JumpForce = 8f;
    public float AD_Speed = 8f;
    public float WS_Speed = 8f;
    public Transform groundCheckTransform;

    // Start is called before the first frame update.
    void Start()
    {
        RBCOMP = GetComponent<Rigidbody>();
    }

    // Update is called once per frame expample if your pc/laptop runs on 30fps.
    void Update()
    {

        // This checks if you pressed the space button to make you jump!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }
         
        // These get the WASD control settings from unitys input manager!
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    // This void is used best with physics thats why the controls and seperated on handles the physics and one handles the inputs kinda.
    private void FixedUpdate()
    {
        // This line make you only have the ability to jump once and not jump more than once!
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length == 1)
        {
            return;
        }

        // And this if statment makes you jump and its here because if you add it in the update void and not the fixedUpdate void it won run well with unitys physics engine so anything realating with physics you should add it in fixedUpdate void.
        if (jumpKeyWasPressed)
        {
            RBCOMP.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

        // After the X and Y position's are set these 2 lines of code make you have the ability to use the WASD controls on your keyborad.
        RBCOMP.velocity = new Vector3(horizontalInput * AD_Speed, RBCOMP.velocity.y, 0);
        RBCOMP.velocity = new Vector3(RBCOMP.velocity.x, RBCOMP.velocity.y, verticalInput * WS_Speed);
    }
}