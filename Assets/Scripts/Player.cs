using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Animator anim;

    private int state;
    public static int IDLE = 0;
    public static int WALK = 1;
    public static int ATTACK = 2;
    public bool holding;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //holding = false;
    }

    // Update is called once per frame
    void Update()
    {     
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            state = WALK;
        } else
        {
            state = IDLE;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            state = ATTACK;
        }

        anim.SetInteger("State", state);
    }

    private void FixedUpdate()
    {

    }
}
