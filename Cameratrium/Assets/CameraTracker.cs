using UnityEngine;
using System.Collections;

public class CameraTracker : MonoBehaviour {

    public GameObject Player = null;
    Vector3 playerpos = Vector3.zero;
    Vector3 CamPos = Vector3.zero;
    public GameObject CamChild = null;
    public GameObject CamPivot = null;


	// Use this for initialization
	void Start () {
        
        if(Player != null)
        {
            playerpos = Player.transform.position;
        }

        print(CamChild.transform.localPosition.z);
	
	}
	
	// Update is called once per frame
	void Update () {
        //debug to all four corners of the screen
        //raycast to all four corners fo the screen. 
        //Zoom in until it dont happen no mo
        //All Logs../

        //I need to comment everything
        //I need to rotate the object left, then right, then up, then down, then zoom in. Check the distance for all of those (distance from where camera currently is), then do the shortest of them.


        //if no blockage, slowly interpolate back to the uh, the normal dist.

        //eventually switch the raycast to player to cam.

        //Detect blockage
        //while()
        //for(var i = 0; i == )
        bool blah = CheckCorners();
        print(blah);



        //http://forum.unity3d.com/threads/camera-tweening-interpolation.25520/
        //https://distance.digipen.edu/2015-fall/pluginfile.php/37573/mod_resource/content/1/GAT315_Lecture06_Cameras.pdf


        if (Player != null)
        {
            if(Vector3.Distance(this.gameObject.transform.position, Player.transform.position) >= 1)
            {
                playerpos = Player.transform.position;

                //print(Vector3.Distance(this.gameObject.transform.position, Player.transform.position));

                CamPos = CamChild.transform.position;
                //this.gameObject.transform.position = Player.transform.position;
                CamChild.transform.position = CamPos;
            }
            this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, playerpos, Time.deltaTime * 2);
            this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, Player.transform.rotation, Time.deltaTime);

            //this.gameObject.transform
        }
	}
    bool CheckCorners()
    {
        bool ishitting = false;
        //every frame, shoot a ray from the parent to the cam. If blockage, shorten the camera's distance. 
        //Debug.DrawLine(CamPivot.transform.position, CamChild.transform.position, Color.white, 0f, true);
        Camera camera = CamChild.GetComponent<Camera>();
        Debug.DrawLine(CamPivot.transform.position, camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane)), Color.yellow, 0f, true);
        Debug.DrawLine(CamPivot.transform.position, camera.ViewportToWorldPoint(new Vector3(0, 1, camera.nearClipPlane)), Color.yellow, 0f, true);
        Debug.DrawLine(CamPivot.transform.position, camera.ViewportToWorldPoint(new Vector3(1, 0, camera.nearClipPlane)), Color.yellow, 0f, true);
        Debug.DrawLine(CamPivot.transform.position, camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane)), Color.yellow, 0f, true);

        float dist = Vector3.Distance(camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane)), CamPivot.transform.position);
        RaycastHit hit;

        if (Physics.Raycast(CamPivot.transform.position, (camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane)) - CamPivot.transform.position), out hit, dist))
        {
            ishitting = true;
            //print("Top Right");
            //print(Time.time);
        }
        if (Physics.Raycast(CamPivot.transform.position, (camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane)) - CamPivot.transform.position), out hit, dist))
        {
            ishitting = true;

            //print("bottom left");
            //print(Time.time);
        }
        if (Physics.Raycast(CamPivot.transform.position, (camera.ViewportToWorldPoint(new Vector3(0, 1, camera.nearClipPlane)) - CamPivot.transform.position), out hit, dist))
        {
            ishitting = true;

            // print("bottom right");
            //print(Time.time);
        }
        if (Physics.Raycast(CamPivot.transform.position, (camera.ViewportToWorldPoint(new Vector3(1, 0, camera.nearClipPlane)) - CamPivot.transform.position), out hit, dist))
        {
            ishitting = true;

            //print("top left");
            //print(Time.time);
        }
        //return ishitting;
        return ishitting;
        //print("Can Confirm, is called");
    }
}
