using UnityEngine;
using System.Collections;

public class Teleportbutton : MonoBehaviour
{
    GameObject lastKnownSafePos = null;
    

    public GameObject T1 = null;
    public GameObject T2 = null;
    public GameObject T3 = null;
    public GameObject T4 = null;
    public GameObject T5 = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
        if (Input.GetKey(KeyCode.T))
        {

            if (Input.GetKeyDown((KeyCode.Alpha1)))
            {
                if (T1 != null)
                {
                    this.gameObject.transform.position = T1.transform.position;
                    this.gameObject.transform.rotation = T1.transform.rotation;
                }
            }
            if (Input.GetKeyDown((KeyCode.Alpha2)))
            {
                if (T2 != null)
                {
                    this.gameObject.transform.position = T2.transform.position;
                    this.gameObject.transform.rotation = T2.transform.rotation;

                }
            }
            if (Input.GetKeyDown((KeyCode.Alpha3)))
            {
                if (T3 != null)
                {
                    this.gameObject.transform.position = T3.transform.position;
                    this.gameObject.transform.rotation = T3.transform.rotation;

                }
            }
            if (Input.GetKeyDown((KeyCode.Alpha4)))
            {
                if (T4 != null)
                {
                    this.gameObject.transform.position = T4.transform.position;
                    this.gameObject.transform.rotation = T4.transform.rotation;

                }
            }
            if (Input.GetKeyDown((KeyCode.Alpha5)))
            {
                if (T5 != null)
                {
                    this.gameObject.transform.position = T5.transform.position;
                    this.gameObject.transform.rotation = T5.transform.rotation;

                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Death")
        {
            print("Death");
            print(other.name);
            gameObject.transform.position = lastKnownSafePos.transform.position;
            gameObject.transform.rotation = lastKnownSafePos.transform.rotation;
        }
        if (other.tag == "Player")
        {
            print(other.gameObject);
            lastKnownSafePos = other.gameObject;
        }
    }
}
