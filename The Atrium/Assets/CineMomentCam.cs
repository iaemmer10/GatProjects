using UnityEngine;
using System.Collections;

public class CineMomentCam : MonoBehaviour
{
    //on enter, swap cams
    //the cam is focused on the thing 24/7
    //after timer is up, swap back


    public GameObject PlayerCam = null;
    public GameObject InterpObj = null;

    public float timer = 4.0f;
    bool hasTriggered = false;

    // Use this for initialization
    void Start()
    {
        if(PlayerCam == null)
        {
            Destroy(this);

        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            PlayerCam.GetComponent<Camera>().enabled = true;
            InterpObj.GetComponent<Camera>().enabled = false;
            Destroy(gameObject);
        }
       // Grp.Update(Time.smoothDeltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        print("Works...?")
        if(other.tag == "Player" && hasTriggered == false && PlayerCam != null)
        {

            hasTriggered = true;
            PlayerCam.GetComponent<Camera>().enabled = false;
            InterpObj.GetComponent<Camera>().enabled = true;
            InterpObj.transform.position = PlayerCam.transform.position;
            InterpObj.transform.rotation = PlayerCam.transform.rotation;
            
            //var grp = ActionSystem.Action.Group(seq, false);

            //ActionSystem.Action.Property(grp, this.gameObject.transform.GetProperty(o => o.position), this.gameObject.transform.position, 3, Ease.QntInOut);



        }
    }
}
