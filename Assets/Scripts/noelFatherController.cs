using UnityEngine;

public class noelFatherController : MonoBehaviour
{
    public float driftFactor = 0.95f;
    public float ivmeFactor = 30.0f;
    public float turnFactor = 3.5f;
    //public float maxSpeed = 20;


    float ivmeInput = 0;
    float steeringInput = 0;

    float rotationAngle = 0;

    //float velocityVsUp = 0;


    [SerializeField] private int giftCounter;



    Rigidbody2D rb;
    GameManager gameManager;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }


    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        ApplyEngineForce();

        ApplySteering();

        KillDikeyVelocity();
    }

    void ApplyEngineForce()
    {

        //velocityVsUp = Vector2.Dot(transform.up, rb.linearVelocity);

        //if(velocityVsUp >maxSpeed&&ivmeInput>0)
        //{
        //    return;
        //}

        //if(velocityVsUp < -maxSpeed * 0.5f && ivmeInput < 0)
        //{
        //    return;
        //}

        //if (rb.linearVelocity.sqrMagnitude > maxSpeed * maxSpeed && ivmeInput > 0)
        //{
        //    return;
        //}

        if (ivmeInput == 0)
        {
            rb.linearDamping = Mathf.Lerp(rb.linearDamping, 3.0f, Time.fixedDeltaTime * 3);

        }
        else
        {
            rb.linearDamping = 0;
        }

        Vector2 engineForceVector = transform.up * ivmeInput * ivmeFactor;

        rb.AddForce(engineForceVector * Time.deltaTime, ForceMode2D.Force);
    }

    void ApplySteering()
    {

        float minSpeedBeforeAllowTurningFactor = (rb.linearVelocity.magnitude / 8);
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);
        
        rotationAngle -= steeringInput * turnFactor;

        rb.MoveRotation(rotationAngle);
    }

    void KillDikeyVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.linearVelocity, transform.up);
        Vector2 rightVelocity = transform.right*Vector2.Dot(rb.linearVelocity, transform.right);

        rb.linearVelocity = forwardVelocity + rightVelocity * driftFactor;
    }


    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        ivmeInput = inputVector.y;

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Goblin")) {
            gameManager.goblinCount++;
            Destroy(other.gameObject);
            giftCounter--;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Gift")) {
            gameManager.giftCount++;
            Destroy(other.gameObject);
            giftCounter--;
        }
    }
}
