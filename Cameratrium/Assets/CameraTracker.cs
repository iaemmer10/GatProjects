using UnityEngine;
using System.Collections;

public class CameraTracker : MonoBehaviour {

    public GameObject Player = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.localRotation = Player.transform.localRotation;

        //http://forum.unity3d.com/threads/camera-tweening-interpolation.25520/
        //https://distance.digipen.edu/2015-fall/pluginfile.php/37573/mod_resource/content/1/GAT315_Lecture06_Cameras.pdf


        if (Player != null)
        {

            print(Vector3.Distance(this.gameObject.transform.position, Player.transform.position));
        }
	}
}
