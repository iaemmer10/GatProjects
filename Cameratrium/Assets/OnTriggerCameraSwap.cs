using UnityEngine;
using System.Collections;

public class OnTriggerCameraSwap : MonoBehaviour
{

    public GameObject MainCam = null;
    public GameObject FstCam = null;
    public GameObject SndCam = null;

    GameObject TargetCam = null;
    GameObject InterpolatedCam = null;
    bool Collided = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if exists, Interpolate to target every frame
        if(InterpolatedCam != null && TargetCam != null)
        {
            InterpolatedCam.transform.position = Vector3.Lerp(InterpolatedCam.transform.position, TargetCam.transform.position, (Time.deltaTime * 0.9f));
            InterpolatedCam.transform.rotation = Quaternion.Slerp(InterpolatedCam.transform.rotation, TargetCam.transform.rotation, (Time.deltaTime * 0.9f));

            if (Vector3.Distance(InterpolatedCam.transform.position, TargetCam.transform.position) < 0.01)
            {
                //If within range, destroy interpolatecam and set targetcamera real
                print("Within Dist");
                Camera camon = TargetCam.GetComponent<Camera>();
                camon.enabled = true;

                Destroy(InterpolatedCam);
            }
        }

        //On enter/exit change target. 



        /*
        if(InterpolatedCam != null)
        {

            if(Collided == false)
            {
                print("interpolating to rail");
                InterpolatedCam.transform.position = Vector3.Lerp(InterpolatedCam.transform.position, SndCam.transform.position, (Time.deltaTime * 0.9f));
                InterpolatedCam.transform.rotation = Quaternion.Slerp(InterpolatedCam.transform.rotation, SndCam.transform.rotation, (Time.deltaTime * 0.9f));

                if (Vector3.Distance(InterpolatedCam.transform.position, SndCam.transform.position) < 0.01)
                {
                    print("Within Dist");
                    Camera camon = SndCam.GetComponent<Camera>();
                    camon.enabled = true;

                    Destroy(InterpolatedCam);
                }
            }
            else
            {
                print("interplating to follow");
                InterpolatedCam.transform.position = Vector3.Lerp(InterpolatedCam.transform.position, MainCam.transform.position, (Time.deltaTime * 0.9f));
                InterpolatedCam.transform.rotation = Quaternion.Slerp(InterpolatedCam.transform.rotation, MainCam.transform.rotation, (Time.deltaTime * 0.9f));

                if (Vector3.Distance(InterpolatedCam.transform.position, MainCam.transform.position) < 0.01)
                {
                    print("Within Dist");
                    Camera camon = MainCam.GetComponent<Camera>();
                    camon.enabled = true;

                    Destroy(InterpolatedCam);
                }
            }
            
        }
        */
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Set the targetcam, make the current cam disabled, create the interpolated cam
            if (InterpolatedCam == null)
            {
                //Create the interpolated camera
                InterpolatedCam = Instantiate(MainCam);
                CameraLock des = InterpolatedCam.GetComponent<CameraLock>();
                Destroy(des);
                AudioListener des2 = InterpolatedCam.GetComponent<AudioListener>();
                Destroy(des2);
                //reset the interpolate'd position
                InterpolatedCam.transform.position = MainCam.transform.position;
                InterpolatedCam.transform.rotation = MainCam.transform.rotation;
            }


            TargetCam = SndCam;
            //Turn off maincam
            Camera camoff = MainCam.GetComponent<Camera>();
            camoff.enabled = false;


            /*
            //Collided = true;
            print("Player");

            //If the interpolated cam doesn't already exist,
            if(InterpolatedCam == null)
            {
                //Create the interpolated camera
                InterpolatedCam = Instantiate(MainCam);
                CameraLock des = InterpolatedCam.GetComponent<CameraLock>();
                Destroy(des);
                AudioListener des2 = InterpolatedCam.GetComponent<AudioListener>();
                Destroy(des2);
            }
            //reset the interpolate'd position
            InterpolatedCam.transform.position = MainCam.transform.position;
            InterpolatedCam.transform.rotation = MainCam.transform.rotation;

            //Turn off maincam
            Camera camoff = MainCam.GetComponent<Camera>();
            camoff.enabled = false;
            //Turn on the 2nd cam
            //Camera camon = SndCam.GetComponent<Camera>();
            //camon.enabled = true;
            */

        }

        //I need to spawn a new camera at position and coordinates of "Orig Cam"
        //I need to set the new cam as the default camera
        //I need to interpolate the new cam's pos and orient to "2nd cam"
        //when I am within a certain distance, I need to set the newcam as the default cam

        //On collide exit I need to do the same thing in reverse
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Collided = false;
            print("Out");

            //Set the targetcam, make the current cam disabled, create the interpolated cam
            if (InterpolatedCam == null)
            {
                //Create the interpolated camera
                InterpolatedCam = Instantiate(SndCam);
                //reset the interpolate'd position
                InterpolatedCam.transform.position = SndCam.transform.position;
                InterpolatedCam.transform.rotation = SndCam.transform.rotation;
            }


            TargetCam = MainCam;
            //Turn off maincam
            Camera camoff = SndCam.GetComponent<Camera>();
            camoff.enabled = false;

            /*
            //If the interpolated cam doesn't already exist,
            if (InterpolatedCam == null)
            {
                print("created cam");
                //Create the interpolated camera
                InterpolatedCam = Instantiate(SndCam);
            }
            else
            {
                print("Cam already exists");
            }
            //reset the interpolate'd position
            InterpolatedCam.transform.position = SndCam.transform.position;
            InterpolatedCam.transform.rotation = SndCam.transform.rotation;


            Camera camoff = MainCam.GetComponent<Camera>();
            camoff.enabled = true;

            Camera camon = SndCam.GetComponent<Camera>();
            camon.enabled = false;*/
        }
    }
}
