using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Unity.Jobs;

public class cutsceneanimation : MonoBehaviour
{

    public Image bakery;
    public Image happy;
    float timer = 0f; 


    //public Sprite happyfamily;
    //public Sprite bakery;

    void Start()
    {
        happy.enabled = true; 
        bakery.enabled = false;
    }

    void Update()
    {
        timer+= Time.deltaTime;
        if (timer > 5f)
        {
            happy.enabled = false;
            bakery.enabled = true;

            timer = 0f; 
        }


        /*if (timer < 5f)
        {
            happy.enabled = true;
            bakery.enabled = false;
        }*/

        



        if (Input.GetKeyDown(KeyCode.D))
        {
            SceneManager.LoadScene("DecorativeScene");
        }

    }

    }