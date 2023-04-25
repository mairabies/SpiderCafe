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
        interactable = GetComponent<Interactable>();
    }

    public void buttonMethod()
    {
        if (interactable.hold)
        {
            gameObject.transform.SetParent(player.transform, true);
        }
        else if (!interactable.hold)
        {
            Debug.Log("release");
            gameObject.transform.SetParent(null, true);
        }
    }
}
