using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float jumpPower;
    public float turnSpeed;
    private Animator anim;
    private bool interactable;

    private int state;
    public static int IDLE = 0;
    public static int WALK = 1;
    public static int ATTACK = 2;
    public static int ATTACK2 = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y, vertical * speed);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
        }
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            state = WALK;
        } else
        {
            state = IDLE;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            state = ATTACK;
        }

        if (Input.GetKey(KeyCode.E))
        {
            state = ATTACK2;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            //transform.Rotate(0f, -turnSpeed * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.Rotate(0f, turnSpeed * Time.deltaTime, 0f);
        }

        anim.SetInteger("State", state);
    }

    private void FixedUpdate()
    {

    }

    private void OnCollisionStay(Collision collision)
    {
       
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }
}
