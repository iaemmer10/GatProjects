using UnityEngine;
using System.Collections;

public class OnCollideLoadEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
    }
    void OnTriggerEnter(Collider other)
    {
        print("Yaaay");
        Destroy(this.gameObject);
        Application.LoadLevelAdditive(3);
    }
}
