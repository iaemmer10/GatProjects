using UnityEngine;
using System.Collections;

public class ScrollUP : MonoBehaviour {

    //public GameObject IHATELIFE;
    public float Timer = 5.0f;
    public int LevelToLoad = 1;



    private float counter = 0;
    //public Text text;
	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
       // print(counter);
        if(counter > Timer)
        {
            //IHATELIFE.StartOptions.StartButtonClicked();
            Application.LoadLevel(LevelToLoad);
            gameObject.SetActive(false);
        }


    }
}
