using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent ue;
    public GameObject button;
    public bool hold;
    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                hold = true;
                ue.Invoke();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                hold = false;
                ue.Invoke();
            }
        }
    }

}
