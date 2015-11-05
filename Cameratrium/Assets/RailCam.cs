using UnityEngine;
using System.Collections;

public class RailCam : MonoBehaviour {
    public GameObject Player;
    public GameObject Child;
    public float CamDist = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, Player.transform.position.y, gameObject.transform.position.z);

        //print(Vector3.Distance(Player.transform.position, Child.transform.position));
        /*
        if(Vector3.Distance(Player.transform.position, Child.transform.position) > CamDist + 1)
        {
            Child.transform.Translate(0f, 0f, 0.1f);
        }
        else if (Vector3.Distance(Player.transform.position, Child.transform.position) < CamDist -1)
        {
            Child.transform.Translate(0f, 0f, -0.1f);
        }*/
	}
}
