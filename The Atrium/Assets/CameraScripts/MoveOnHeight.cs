using UnityEngine;
using System.Collections;

public class MoveOnHeight : MonoBehaviour {
    //Vector3 origPosition = Vector3.zero;
    public GameObject RotSphere = null;

    float StartingDistance = 0f;
 

	// Use this for initialization
	void Start () {
        //origPosition = this.gameObject.transform.localPosition;
        //save the distance until hitting the ground

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 100f))
        {
            StartingDistance = hit.distance;
            //print(hit.distance);
        }
	}
	
	// Update is called once per frame
	void Update () {

        //if your distance from orig position is greater than 30, do nothing
        //otherwise, raycast downards every frame 5 height
        //raycast down every frame
        //if the raycast is gr

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 100f))
        {
            if(hit.collider.tag == "Ramp")
            {
                var dist = StartingDistance - hit.distance;

                
                if(dist > 1.6f)
                {
                    dist = 1.6f;
                }
                else if(dist < -1.6f)
                {
                    dist = -1.6f;
                }
                //RotSphere.transform.localRotation = Quaternion.EulerAngles(new Vector3(-dist*0.5f, 0, 0));
                RotSphere.transform.localRotation = Quaternion.Slerp(RotSphere.transform.localRotation, Quaternion.EulerAngles(new Vector3(-dist * 0.5f, 0, 0)), Time.deltaTime);

                //gameObject.transform.position = Vector3(gameObject.transform.position.x, hit.point.y + 1.5f, gameObject.transform.position.z);
                //gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, new  Vector3(gameObject.transform.position.x, hit.point.y + 1.5f, gameObject.transform.position.z), Time.deltaTime);

            }



        }
    }
}
