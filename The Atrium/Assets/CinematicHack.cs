using UnityEngine;
using System.Collections;

public class CinematicHack : MonoBehaviour {


    //Interpolate the Zoom, the position, and the look angle to match the main one, then delete and set main cam real

    public GameObject MainCam = null;

    bool rotate = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(rotate)
        {
            gameObject.transform.Rotate(-Vector3.right * Time.deltaTime*4);// == new Vector3(0, 0, Mathf.Deg2Rad(1));
        }
	}
}
