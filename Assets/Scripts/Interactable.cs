using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent ue;
    private GameObject button;
    public bool hold;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject;
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //player.holding = hold;


        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                hold = !hold;
                ue.Invoke();
            }
        }
    }

}
