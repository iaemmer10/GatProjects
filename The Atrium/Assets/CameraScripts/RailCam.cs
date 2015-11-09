using UnityEngine;
using System.Collections;

public class RailCam : MonoBehaviour {
    public GameObject Player;
    public GameObject Child;
    //public float CamDist = 10;

    public bool XAxe = true;
    public bool YAxe = true;
    public bool ZAxe = true;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (XAxe == true)
        {
            //gameObject.transform.position = new Vector3(Player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(Player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Time.deltaTime);
        }
        if (YAxe == true)
        {
            //gameObject.transform.position = new Vector3(gameObject.transform.position.x, Player.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(gameObject.transform.position.x, Player.transform.position.y, gameObject.transform.position.z), Time.deltaTime);
        }
        if (ZAxe == true)
        {
            //gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, Player.transform.position.z);
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, Player.transform.position.z), Time.deltaTime);
        }
	}
    public void SwapX()
    {

    }
}
