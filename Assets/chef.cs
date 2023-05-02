using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class chef : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject spider;
    //[SerializeField] GameObject b;
    [SerializeField] private Transform Destination;
    [SerializeField] private float speed;
    [SerializeField] bool taunted = false;
    [SerializeField] GameObject cupcake;
    float spidery = 0f; 
    float chefWaitTimer = 0f;
    private Vector3 tempDestination; // works but doesnt go all the way to counter, can stop in middle for no reason

    /*void Start()
    {
        tempDestination = new Vector3(Random.Range(-17.13f ,- 2.81f), 6.3f, Random.Range(5.79f, 19.85f));
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, tempDestination, speed);

        if (transform.position == tempDestination)
        {
            tempDestination = new Vector3(Random.Range(-17.13f, -2.81f), 6.3f, Random.Range(5.79f, 19.85f));
        }
    }*/

    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    void Start()
    {
        //b = new GameObject();
        Debug.Log("start");
        transform.position += transform.forward * Time.deltaTime * speed;

        //rb.AddForce(Vector3.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "ground")
        {

            if (taunted == true)
            {
                spidery = spider.transform.position.y;
                rb.velocity = new Vector3(0, 0, 0);
                GameObject b = Instantiate(cupcake, new Vector3(spider.transform.position.x, spider.transform.position.y + 5f, spider.transform.position.z), Quaternion.identity);
                taunted = false;

            }
            Debug.Log("on collision");
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, Random.Range(-180f, 180f), transform.eulerAngles.z);

            transform.position += transform.forward * Time.deltaTime * speed;
        }

        if (collision.gameObject.tag == "cupcake")
        {
            Debug.Log("Spider dead lolz");
            spider.SetActive(false);
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("taunted");
            Vector3 targetPosition = new Vector3(spider.transform.position.x, spider.transform.position.y, spider.transform.position.z);
            transform.LookAt(targetPosition);
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
            taunted= true;
        }

        /*if (b.transform.position.y <= spidery)
        {
            Destroy(b);
            Debug.Log("destroyed cupcake");
        }*/

        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
