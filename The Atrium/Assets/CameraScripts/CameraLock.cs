using UnityEngine;
using System.Collections;

public class CameraLock : MonoBehaviour {

    public GameObject Target;

	// Use this for initialization
	void Start () {
        transform.LookAt(Target.transform.position);
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Target.transform.position);
    }
}
