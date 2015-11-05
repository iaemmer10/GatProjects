using UnityEngine;
using System.Collections;

public class Teleportbutton : MonoBehaviour {

    public GameObject T1 = null;
    public GameObject T2 = null;
    public GameObject T3 = null;
    public GameObject T4 = null;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown((KeyCode.Alpha1)))
        {
            if (T1 != null)
            {
                this.gameObject.transform.position = T1.transform.position;
            }
        }
        if (Input.GetKeyDown((KeyCode.Alpha2)))
        {
            if (T2 != null)
            {
                this.gameObject.transform.position = T2.transform.position;
            }
        }
        if (Input.GetKeyDown((KeyCode.Alpha3)))
        {
            if (T3 != null)
            {
                this.gameObject.transform.position = T3.transform.position;
            }
        }
        if (Input.GetKeyDown((KeyCode.Alpha4)))
        {
            if (T4 != null)
            {
                this.gameObject.transform.position = T4.transform.position;
            }
        }
    }
}
