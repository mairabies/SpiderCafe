using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public CharacterController characterController;
    public float speed = 5f;
    private Animator anim;
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
            anim.SetInteger("State", WALK);
            characterController.Move(dir * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            anim.SetInteger("State", ATTACK);
        }

        if (Input.GetKey(KeyCode.E))
        {
            anim.SetInteger("State", ATTACK2);
        }

    }

    private void FixedUpdate()
    {

    }
}
