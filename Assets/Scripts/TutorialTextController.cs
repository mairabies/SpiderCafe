using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialTextController : MonoBehaviour
{
    // Start is called before the first frame update

     TextMeshProUGUI joe;
    bool cupcakehold = false;
    int clicknumber = 0;
    public TextMeshProUGUI scoreText;
    private int score;
    bool tutorialOver = false; 
    void Start()
    {
        joe = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) && cupcakehold == false && clicknumber==0 && tutorialOver==false)
        {
            joe.text = "Now click on the cupcake and try to move";
        }

        if (Input.GetMouseButtonDown(0) && clicknumber ==0)
        {
            cupcakehold = true;
            clicknumber++;
        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) && cupcakehold == true)
        {
            joe.text = "Click on the cupcake again to realase it.";
            cupcakehold= false;
            
        }

        if (Input.GetMouseButtonDown(0) && cupcakehold == false && clicknumber==1)
        {
            cupcakehold = false;
            clicknumber++;
            tutorialOver = true;
            joe.text = "Well Done! Tutorial Over. +100 Revenge Points";
            score += 100;
            scoreText.text = "Score: " + score;
        }


    }
}
