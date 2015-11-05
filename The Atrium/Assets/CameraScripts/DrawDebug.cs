using UnityEngine;
using System.Collections;

public class DrawDebug : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Debug.DrawRay(this.gameObject.transform.position + new Vector3(0, 1f, 0), this.gameObject.transform.forward, Color.white, 0.1f, true);

    }
}
