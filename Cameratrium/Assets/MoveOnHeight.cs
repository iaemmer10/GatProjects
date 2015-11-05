using UnityEngine;
using System.Collections;

public class MoveOnHeight : MonoBehaviour {
    Vector3 origPosition = Vector3.zero;

	// Use this for initialization
	void Start () {
        origPosition = this.gameObject.transform.localPosition;
	    //save the distance until hitting the ground
	}
	
	// Update is called once per frame
	void Update () {

        //if your distance from orig position is greater than 30, do nothing
        //otherwise, raycast downards every frame 5 height
        //raycast down every frame
        //if the raycast is gr

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 10f))
        {
            //if(Vector3.Distance(Vector3(hit.point,0,0), Vector3(0,gameObject.transform.position.y,0)) > 0)
            if (Mathf.Abs(gameObject.transform.position.y - hit.point.y) > 3)
            {
                print("Greater than five");
             
            }
            else
            {
                //print(hit.point);
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, hit.point.y + 1.5f, gameObject.transform.position.z);

            }



        }
    }
}
