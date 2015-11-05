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
            InterpolatedCam.transform.position = Vector3.Lerp(InterpolatedCam.transform.position, TargetCam.transform.position, (Time.deltaTime * 0.999f));
            InterpolatedCam.transform.rotation = Quaternion.Slerp(InterpolatedCam.transform.rotation, TargetCam.transform.rotation, (Time.deltaTime * 0.9f));
            if(TargetCam == SndCam)
            {
                InterpolatedCam.transform.position = Vector3.Lerp(InterpolatedCam.transform.position, TargetCam.transform.position, (Time.deltaTime));
            }

            if (Vector3.Distance(InterpolatedCam.transform.position, TargetCam.transform.position) < 0.1)
            {
                //If within range, destroy interpolatecam and set targetcamera real
                print("Within Dist");
                Camera camon = TargetCam.GetComponent<Camera>();
                TargetCam.tag = "MainCamera";
                camon.enabled = true;


                Destroy(InterpolatedCam);
            }
        }

        //On enter/exit change target. 
        
    }
    void OnTriggerEnter(Collider other)
    {
        print("Collided");
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
        }
    }
}
