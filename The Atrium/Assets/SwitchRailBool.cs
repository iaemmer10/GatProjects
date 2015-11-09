using UnityEngine;
using System.Collections;

public class SwitchRailBool : MonoBehaviour {

    public GameObject thingToSwitch;
    RailCam scriptchange;

    public bool XAxe;
    public bool YAxe;
    public bool ZAxe;

    // Use this for initialization
    void Start () {
        scriptchange = thingToSwitch.GetComponent<RailCam>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") ;
        {
            scriptchange.YAxe = YAxe;

            scriptchange.XAxe = XAxe;

            scriptchange.ZAxe = ZAxe;

        }
    }
}
