using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public CharacterController characterController;
    public float speed = 5f;
    private Animator anim;

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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;

        if (dir.magnitude >= 0.1f)
        {
            state = WALK;
            characterController.Move(dir * speed * Time.deltaTime);
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
        

        anim.SetInteger("State", state);
    }

    private void FixedUpdate()
    {

    }
}
