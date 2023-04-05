using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class action : MonoBehaviour
{
    private Player player;
    private bool vis = true;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();    
    }

    public void buttonMethod()
    {
        Debug.Log("clicked");
        gameObject.transform.SetParent(player.transform, true);
    }
}
