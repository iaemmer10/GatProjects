using UnityEngine;
using System.Collections;

public class playcrashscript : MonoBehaviour {


    public float TIMER = 2.0f;
    public bool HASTRIGGERED = false;
    public GameObject MYBRAND = null;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {


        if (HASTRIGGERED == false)
        {
            HASTRIGGERED = true;
            if (MYBRAND != null)
            {
                var audio = GetComponent<AudioSource>();
                audio.PlayOneShot(audio.clip);
                MYBRAND.active = true;
                //gameObject.active = false;
                //MYBRAND.AddComponent("Rigidbody") as Rigidbody;
                Rigidbody gameObjectsRigidBody = MYBRAND.AddComponent<Rigidbody>(); // Add the rigidbody.

            }

        }


        //if (bool), find GAMEOBJET, attach rigid body,Wait TIMER, then PLAY NEW NOISE
    }
    void OnCollisionEnter(Collision col)
    {
        //var audio = GetComponent<AudioSource>();
        

        if (HASTRIGGERED == false)
        {
            //gameObject.active = false;
            HASTRIGGERED = true;
            var audio = GetComponent<AudioSource>();
            audio.PlayOneShot(audio.clip);
        }
    }


        //if (bool), find GAMEOBJET, attach rigid body,Wait TIMER, then PLAY NEW NOISE
    
}
