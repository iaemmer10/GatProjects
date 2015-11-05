using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fader : MonoBehaviour {

    Image image;
    void Start()
    {
        image = GetComponent<Image>();

        Color c = image.color;
        c.a = 100;
        image.color = c;
    }
	
	// Update is called once per frame
	void Update () {
        Color c = image.color;
        c.a += 20;
        image.color = c;
        //gameObject.image.color += Vector4(0, 0, 0, 1);
    }
}

