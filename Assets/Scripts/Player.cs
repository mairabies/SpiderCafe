using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
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
        float vertical = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        Vector3 dir = new Vector3(0f, 0f, vertical).normalized;

        if (dir.magnitude >= 0.1f)
        {
            state = WALK;
            rb.MovePosition(dir);
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
            transform.Rotate(0f, -turnSpeed * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, turnSpeed * Time.deltaTime, 0f);
        }

        anim.SetInteger("State", state);
    }

    private void FixedUpdate()
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Interactable"))
        {
            Debug.Log("colliding");
            interactable = true;

            //have Interactions script and bool interactable inside. Set to true when collidiing, when true make "F to interact" variable visible
            //Problem: how to choose which object to select when colliding with more than one
            //interactable bool will also be condition for picking up and moving stuff
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Interactable"))
        {
            Debug.Log("exited collision");
            interactable = false;
        }
    }
}
