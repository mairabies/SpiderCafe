using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class action : MonoBehaviour
{
    private Player player;
    Interactable interactable;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        interactable = GameObject.Find("Cube").GetComponent<Interactable>();
    }

    public void buttonMethod()
    {
        if (interactable.hold)
        {
            Debug.Log("held");
            gameObject.GetComponentInParent<Transform>().SetParent(player.transform, true);
        } else
        {
            Debug.Log("unheld");
            player.GetComponentInChildren<Transform>().SetParent(gameObject.transform, true);
        }
        //gameObject.GetComponentInParent<GameObject>().transform.SetParent(player.transform, true);
    }
}
