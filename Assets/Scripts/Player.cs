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
    public static int DEATH = 3;
    public bool holding;
    public Vector2 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //holding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            state = WALK;
        } else
        {
            state = IDLE;
        }

        if (Input.GetKey(KeyCode.C))
        {
            state = ATTACK;
        }

        anim.SetInteger("State", state);
    }

    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Interactable"))
        {
            Debug.Log("collide");
            Death();
        }
    }

    void Death()
    {
        state = DEATH;
        anim.SetInteger("State", state);
        transform.position = respawnPoint;
    }
}
