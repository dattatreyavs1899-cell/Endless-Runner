using System.Collections;
using UnityEngine;

public class movement : MonoBehaviour
{
    public static movement instance;

    [Header("Player Movement")]
    [SerializeField] private float playerSpeed = 2;
    [SerializeField] private float boostMultiplier = 1.5f;
    [SerializeField] private float boostInterval = 3f;
    [SerializeField] private float horizontalSpeed = 2;
    private float originalPlayerSpeed = 0;

    [Header("Jumping")]
    [SerializeField] private float jumpPower = 2;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private int maxJumps = 2;
    private bool isGrounded;
    private int keyCount = 0;

    [Header("Player Limits")]
    [SerializeField] private float rightLimit = 5.5f;
    [SerializeField] private float leftLimit = -5.5f;
    [SerializeField] private float upLimit = -5.5f;
    public float airCooldown = 1;

    [Header("Player Animation")]
    [SerializeField] GameObject thePlayerAnim;

    bool isRunning;

    private Rigidbody rb;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        originalPlayerSpeed = playerSpeed;
        rb = GetComponent<Rigidbody>();
        jumpPower += 10;
        keyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (isRunning == false)
        {
            isRunning = true;
            StartCoroutine(AddDistance());
        }

        Debug.Log(keyCount);

        transform.Translate(Vector3.forward * Time.deltaTime *  playerSpeed, Space.World );

        if (Input.GetKey( KeyCode.A ) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > leftLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * 10);
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < rightLimit)
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed * 10);
            }
        }

        GroundCheck();

        /*if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && speedPwr > 0) 
        {

            Debug.Log("boost");
            
                playerSpeed = playerSpeed + (pwrUp * 2);
                speedPwr--;
                
               /* new WaitForSeconds(pwrTime * Time.deltaTime);
                playerSpeed = playerSpeed - (pwrUp / 10);
                Debug.Log("boostdective");//
        }*/


    }

    public void ApplyBoost()
    {
        StartCoroutine(BoostCoroutine());
    }

    IEnumerator BoostCoroutine()
    {
        playerSpeed = originalPlayerSpeed * boostMultiplier;
        yield return new WaitForSeconds(boostInterval);
        playerSpeed = originalPlayerSpeed;
    }

    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && rb.angularVelocity.y <= 0.1f)
        {
            keyCount = 0;
            thePlayerAnim.GetComponent<Animator>().Play("Running");
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Pressed Jump");
            thePlayerAnim.GetComponent<Animator>().Play("Jump");
            TryJumping();
        }
    }

    private void TryJumping()
    {
        if(isGrounded || keyCount < maxJumps)
        {
            rb.angularVelocity = new Vector3(rb.angularVelocity.x, 0f, rb.angularVelocity.z);
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            
            keyCount +=1;
            //Debug.Log(keyCount);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    IEnumerator AddDistance()
    {
        yield return new WaitForSeconds(0.7f);
        masterLvlInfo.distanceRun += 1;
        isRunning = false;
    }

}
