using UnityEngine;

public class StrafeMovement : MonoBehaviour
{
    [SerializeField]
    private float accel = 200f;         // How fast the player accelerates on the ground
    [SerializeField]
    private float airAccel = 200f;      // How fast the player accelerates in the air
    [SerializeField]
    private float maxSpeed = 6.4f;      // Maximum player speed on the ground
    [SerializeField]
    private float maxAirSpeed = 0.8f;   // "Maximum" player speed in the air
    [SerializeField]
    private float friction = 8f;        // How fast the player decelerates on the ground
    [SerializeField]
    private float jumpForce = 5f;       // How high the player jumps
    [SerializeField]
    private LayerMask groundLayers;
    public Transform handsParent;

    public CapsuleCollider playerCollider;

    [SerializeField]
    private GameObject camObj;

    private Vector3 handsParentOrigin;
    private float movementCounter;
    private float idleCounter;

    private Vector3 targetHandBobPosition;

    private float lastJumpPress = -1f;
    private float jumpPressDuration = 0.1f;
    public static bool onGround = false;

    private void Update()
    {
        //print(new Vector3(GetComponent<Rigidbody>().velocity.x, 0f, GetComponent<Rigidbody>().velocity.z).magnitude);
        if (Input.GetButton("Jump"))
        {
            lastJumpPress = Time.time;
        }


        //HeadBob
        if (GetComponent<Rigidbody>().velocity.magnitude >= 2)
        {
            HeadBob(movementCounter, 0.05f, 0.05f);
            movementCounter += Time.deltaTime * 3;
            handsParent.localPosition = Vector3.Lerp(handsParent.localPosition, targetHandBobPosition, Time.deltaTime * 10f);
        }
        if (GetComponent<Rigidbody>().velocity.magnitude <= 2)
        {
            HeadBob(idleCounter, 0.01f, 0.01f);
            idleCounter += Time.deltaTime;
            handsParent.localPosition = Vector3.Lerp(handsParent.localPosition, targetHandBobPosition, Time.deltaTime * 10f);
        }

    }


    void HeadBob(float p_z, float p_x_intensity, float p_y_intensity)
    {
        targetHandBobPosition = handsParentOrigin = new Vector3(Mathf.Cos(p_z) * p_x_intensity, Mathf.Sin(p_z * 2) * p_y_intensity, 0);
    }


    private void Start()
    {
        handsParentOrigin = handsParent.localPosition;
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            playerCollider.height = 1;
            maxSpeed = 3.5f;
            maxAirSpeed = 0.3f;
        }
        else
        {
            playerCollider.height = 2;
            maxSpeed = 6.4f;
            maxAirSpeed = 0.6f;
        }

        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Get player velocity
        Vector3 playerVelocity = GetComponent<Rigidbody>().velocity;
        // Slow down if on ground
        playerVelocity = CalculateFriction(playerVelocity);
        // Add player input
        playerVelocity += CalculateMovement(input, playerVelocity);
        // Assign new velocity to player object
        GetComponent<Rigidbody>().velocity = playerVelocity;
    }

    private void Crouching()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            playerCollider.height = 0.8f;
        }
        else
        {
            playerCollider.height = 2;
        }
    }

    /// <summary>
    /// Slows down the player if on ground
    /// </summary>
    /// <param name="currentVelocity">Velocity of the player</param>
    /// <returns>Modified velocity of the player</returns>
	private Vector3 CalculateFriction(Vector3 currentVelocity)
    {
        onGround = CheckGround();
        float speed = currentVelocity.magnitude;

        if (!onGround || Input.GetButton("Jump") || speed == 0f)
            return currentVelocity;

        float drop = speed * friction * Time.deltaTime;
        return currentVelocity * (Mathf.Max(speed - drop, 0f) / speed);
    }

    /// <summary>
    /// Moves the player according to the input. (THIS IS WHERE THE STRAFING MECHANIC HAPPENS)
    /// </summary>
    /// <param name="input">Horizontal and vertical axis of the user input</param>
    /// <param name="velocity">Current velocity of the player</param>
    /// <returns>Additional velocity of the player</returns>
    private Vector3 CalculateMovement(Vector2 input, Vector3 velocity)
    {
        onGround = CheckGround();

        //Different acceleration values for ground and air
        float curAccel = accel;
        if (!onGround)
            curAccel = airAccel;

        //Ground speed
        float curMaxSpeed = maxSpeed;

        //Air speed
        if (!onGround)
            curMaxSpeed = maxAirSpeed;

        //Get rotation input and make it a vector
        Vector3 camRotation = new Vector3(0f, camObj.transform.rotation.eulerAngles.y, 0f);
        Vector3 inputVelocity = Quaternion.Euler(camRotation) *
                                new Vector3(input.x * curAccel, 0f, input.y * curAccel);

        //Ignore vertical component of rotated input
        Vector3 alignedInputVelocity = new Vector3(inputVelocity.x, 0f, inputVelocity.z) * Time.deltaTime;

        //Get current velocity
        Vector3 currentVelocity = new Vector3(velocity.x, 0f, velocity.z);

        //How close the current speed to max velocity is (1 = not moving, 0 = at/over max speed)
        float max = Mathf.Max(0f, 1 - (currentVelocity.magnitude / curMaxSpeed));

        //How perpendicular the input to the current velocity is (0 = 90°)
        float velocityDot = Vector3.Dot(currentVelocity, alignedInputVelocity);

        //Scale the input to the max speed
        Vector3 modifiedVelocity = alignedInputVelocity * max;

        //The more perpendicular the input is, the more the input velocity will be applied
        Vector3 correctVelocity = Vector3.Lerp(alignedInputVelocity, modifiedVelocity, velocityDot);

        //Apply jump
        correctVelocity += GetJumpVelocity(velocity.y);

        //Return
        return correctVelocity;
    }

    /// <summary>
    /// Calculates the velocity with which the player is accelerated up when jumping
    /// </summary>
    /// <param name="yVelocity">Current "up" velocity of the player (velocity.y)</param>
    /// <returns>Additional jump velocity for the player</returns>
	private Vector3 GetJumpVelocity(float yVelocity)
    {
        Vector3 jumpVelocity = Vector3.zero;

        if (Time.time < lastJumpPress + jumpPressDuration && yVelocity < jumpForce && CheckGround())
        {
            lastJumpPress = -1f;
            jumpVelocity = new Vector3(0f, jumpForce - yVelocity, 0f);
        }

        return jumpVelocity;
    }

    /// <summary>
    /// Checks if the player is touching the ground. This is a quick hack to make it work, don't actually do it like this.
    /// </summary>
    /// <returns>True if the player touches the ground, false if not</returns>
    private bool CheckGround()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        bool result = Physics.Raycast(ray, GetComponent<Collider>().bounds.extents.y + 0.1f, groundLayers);
        return result;
    }
}
