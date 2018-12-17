using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    public static bool canClick;

	// Use this for initialization
	void Start () {
        canClick = false;
	}

    void OnMouseOver()
    {
        canClick = true;
    }

    void OnMouseExit()
    {
        canClick = false;
    }
}
