using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCandle : MonoBehaviour {

    GameObject child;
    GameObject thisObject;

	// Use this for initialization
	void Start () {
        thisObject = this.gameObject; //Current Object
        child = thisObject.gameObject.transform.GetChild(0).gameObject; //Child of object
        child.SetActive(false); //Extinguish flame
	}
	
	// Update is called once per frame
	void Update () {
        LightFlame();
	}

    void LightFlame()
    {
        if (Input.GetKeyDown(KeyCode.E)) //If the E key is down
        {
            child.SetActive(true); //Light the Flame
        }
    }

}
