using UnityEngine;
using System.Collections;

public class CameraTracker : MonoBehaviour {

    public GameObject Player = null;
    Vector3 playerpos = Vector3.zero;
    Vector3 CamPos = Vector3.zero;
    public GameObject CamChild = null;
    public GameObject CamPivot = null;

    Vector3 CameraZoom = Vector3.zero;


	// Use this for initialization
	void Start () {
        
        if(Player != null)
        {
            playerpos = Player.transform.position;
        }

        //print(CamChild.transform.localPosition.z);
        CamChild.transform.LookAt(CamPivot.transform.position);
	    CameraZoom = CamChild.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {

        bool checker = true;
        for (var i = 0; checker == true; i++)
        {
            checker = CheckCorners();
            if(i > 100)
            {
                break;
            }
        }
        //CheckCorners();
        //CheckCorners();
        //CheckCorners();
       // CheckCorners();
        //CheckCorners();
        //CheckCorners();
        //CheckCorners();


        if (CheckLength()== true)
        {
            //print(CamChild.transform.localPosition);
            CamChild.gameObject.transform.localPosition = Vector3.Lerp(CamChild.gameObject.transform.localPosition, CameraZoom, Time.deltaTime);

        }


        //http://forum.unity3d.com/threads/camera-tweening-interpolation.25520/
        //https://distance.digipen.edu/2015-fall/pluginfile.php/37573/mod_resource/content/1/GAT315_Lecture06_Cameras.pdf


        if (Player != null)
        {
            playerpos = Player.transform.position;
            if (Vector3.Distance(this.gameObject.transform.position, Player.transform.position) >= 1)
            {
                

                //print(Vector3.Distance(this.gameObject.transform.position, Player.transform.position));

                CamPos = CamChild.transform.position;
                //this.gameObject.transform.position = Player.transform.position;
                CamChild.transform.position = CamPos;
            }
            //this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, playerpos, Time.deltaTime * 2);
            this.gameObject.transform.position = playerpos;
            this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, Player.transform.rotation, Time.deltaTime);

            //this.gameObject.transform
        }
	}
    bool CheckLength()
    {

        //Save the cam position
        Vector3 oldpos = CamChild.transform.position;
        //Teleport it to default
        CamChild.transform.localPosition = CameraZoom;
        //Save the new posistion
        Vector3 newpos = CamChild.transform.position;
        //teleport back to orig position
        CamChild.transform.position = oldpos;

        //Physics raycast from center, to the camera's default
        Camera camera = CamChild.GetComponent<Camera>();
        //Debug.DrawLine(CamPivot.transform.position, CameraZoom + CamPivot.transform.position, Color.yellow, 0f, true);
        Debug.DrawLine(CamPivot.transform.position, newpos, Color.blue, 0f, true);
        //return treu if not hitting anything
        //return false if hitting something

        //If the ray hits anything, return false
        //else return true
        RaycastHit hit;
        float maxdis = Vector3.Distance(CamPivot.transform.position, newpos);

        //print(newpos);
        bool returner = true;
        //Physics.Raycast(CamPivot.transform.position, newpos, out hit, maxdis);
        if(Physics.Raycast(CamPivot.transform.position, newpos - CamPivot.transform.position, out hit, maxdis))
        {
            
            if(hit.collider.tag != "Player")
            {
                //print(hit.collider.name);
                //print(hit.point);
                ///print(hit.collider.gameObject.name);
               // print("Fuck Everything");
                returner = false;
            }
            

        }
        //print(Physics.Raycast(CamPivot.transform.position, newpos, maxdis));

        return returner;
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

        float DiSTs = 0f;

        if (Physics.Raycast(CamPivot.transform.position, (camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane)) - CamPivot.transform.position), out hit, dist))
        {
            if(hit.collider.gameObject.tag != "Player")
            {

                if (DiSTs < hit.distance)
                {
                    DiSTs = hit.distance;
                }

                ishitting = true;
                //print("Top Right");
                //CamChild.transform.localPosition = new Vector3(CamChild.transform.localPosition.x, CamChild.transform.localPosition.y, -hit.distance);

                //print(Time.time);
            }


        }
        if (Physics.Raycast(CamPivot.transform.position, (camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane)) - CamPivot.transform.position), out hit, dist))
        {
            if (hit.collider.gameObject.tag != "Player")
            {
                if (DiSTs < hit.distance)
                {
                    DiSTs = hit.distance;
                }
                ishitting = true;
            }
            //CamChild.transform.localPosition = new Vector3(CamChild.transform.localPosition.x, CamChild.transform.localPosition.y, -hit.distance);
            //print("bottom left");
        }
        if (Physics.Raycast(CamPivot.transform.position, (camera.ViewportToWorldPoint(new Vector3(0, 1, camera.nearClipPlane)) - CamPivot.transform.position), out hit, dist))
        {
            if (hit.collider.gameObject.tag != "Player")
            {
                if (DiSTs < hit.distance)
                {
                    DiSTs = hit.distance;
                }
                ishitting = true;
            }
            //print("top left");

        }
        if (Physics.Raycast(CamPivot.transform.position, (camera.ViewportToWorldPoint(new Vector3(1, 0, camera.nearClipPlane)) - CamPivot.transform.position), out hit, dist))
        {
            if (hit.collider.gameObject.tag != "Player")
            {
                if (DiSTs < hit.distance)
                {
                    DiSTs = hit.distance;
                }
                ishitting = true;
            }
            //print("Bottom Right");
        }

        //return ishitting;
        if(ishitting == true)
        {
            //print(DiSTs);
            //if(Vector3.Distance(CamChild.)
            //print(CamChild.transform.localPosition);
            if(CamChild.transform.localPosition.z < -0.2)
            {
                CamChild.transform.localPosition = new Vector3(CamChild.transform.localPosition.x, CamChild.transform.localPosition.y, CamChild.transform.localPosition.z + 0.01f);
            }
            //CheckCorners();
        }
        return ishitting;
        //print("Can Confirm, is called");
    }
}
