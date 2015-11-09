using UnityEngine;
using System.Collections;
using ActionSystem.Internal;
using ActionSystem; //You either must say "using ActionSystem" or put "ActionSystem." in front of anything having to do with actions.
using System.Reflection;
using System; //If you are usung System, you will need to put "ActionSystem." in front of any calls on the "Action" class.

public class CineCam : MonoBehaviour
{

    public GameObject[] myObjects;
    GameObject Target = null;
    public GameObject FinalCam = null;

    //AimGrp is an actiongroup covering the focus of the camera in every frame
    ActionGroup AimGrp = new ActionGroup();

    public float lerptime = 1f;
    float currentLerpTime = 0f;

    int index = 0;
    //float Timer = 2.0;

    // Use this for initialization
    void Start()
    {
        /*
        print(myObjects.Length);
        if (myObjects.Length > 0)
        {
            print(myObjects[0].name);
            Target = myObjects[index];
        }
        */
        if(Target == null)
        {
            Target = FinalCam;
        }
        SwitchAim(5);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Target != null)
        {

            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerptime)
            {
                currentLerpTime = lerptime;
            }
            float perc = currentLerpTime / lerptime;

            //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, Target.transform.position, perc);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Target.transform.rotation, perc);

            //print(perc);
            //print(perc);
            //print(Target.name);

            if (perc >= 0.1)
            //if(gameObject.transform.position == Target.transform.position)
            {
                /*
                print("there");
                //currentLerpTime = 0;
                index += 1;
                currentLerpTime = 0;
                if (index < myObjects.Length)
                {

                    Target = myObjects[index];
                }
                else
                {
                    Target = FinalCam;
                    if(index == myObjects.Length + 1)
                    {
                        gameObject.GetComponent<Camera>().enabled = false;
                        Target.GetComponent<Camera>().enabled = true;
                    }
                }
                */

            //}

            /*
            if (perc/Time.deltaTime > 1.2)
            {

                
            }
            */
        //}
        AimGrp.Update(Time.deltaTime);


    }
    public void SwitchAim(float timer)
    {
        //Change the AimTracker's Parent so that it's origin is the position of that object.
        //AimTracker.transform.SetParent(newAimTarget.transform);
        //Clear the current action systems on the Aim if there is one. (this is so the object doesnt continue to move in it's current path and adopts the below one instead)
        AimGrp.Clear();
        //Declare a new sequence using AimGrp
        var seq = ActionSystem.Action.Sequence(AimGrp);
        //Interpolate the X position of the AimTracker so that it approaches zero over the course of Timer
        ActionSystem.Action.Property(seq, gameObject.transform.GetProperty(x => x.localPosition), Target.transform.position, timer, Ease.Linear);
        //ActionSystem.Action.Property(seq, gameObject.transform.GetProperty(x => x.rotation.eulerAngles), Target.transform.rotation.eulerAngles, timer, Ease.Linear);
        ActionSystem.Action.Call(seq, Boop);
        //ActionSystem.Action.Call(seq, SwitchAim, timer);
    }
    public void Boop()
    {
        gameObject.GetComponent<Camera>().enabled = false;
        Target.GetComponent<Camera>().enabled = true;
    /*
        print("done");
        print("there");
        //currentLerpTime = 0;
        index += 1;
        currentLerpTime = 0;*/
    /*
        if (index < myObjects.Length)
        {

            Target = myObjects[index];
        }*//*
        else
        {
            Target = FinalCam;
            if (index == myObjects.Length + 1)
            {
               // gameObject.GetComponent<Camera>().enabled = false;
                //Target.GetComponent<Camera>().enabled = true;
            }
        }*/
    }
}
