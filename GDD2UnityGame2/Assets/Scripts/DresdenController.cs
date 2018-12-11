using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public enum HandAction { Free, HoldObject, Flickum}
public class DresdenController : MonoBehaviour
{
    public static Transform Dresden;
    //Key assignments
    const KeyCode FlickumKey = KeyCode.E;
    const KeyCode MagicKey = KeyCode.F;

    //Variables
    HandAction handAction;
    GameObject held = null;

	// Use this for initialization
	void Start () {
        if (Dresden == null) Dresden = transform;
	}
	
	// Update is called once per frame
	void Update () {
        switch (handAction) //Covers scene interactions
        {
            case HandAction.Free:
                if (Input.GetKeyDown(FlickumKey))
                {
                    handAction = HandAction.Flickum;
                    //enable staff light
                }
                if (Input.GetKeyDown(MagicKey))
                {

                }
                break;
            case HandAction.HoldObject:
                if (held == null) handAction = HandAction.Free; //Failsafe
                else
                {

                }
                break;
            case HandAction.Flickum:
                if (Input.GetKeyUp(FlickumKey))
                {
                    handAction = HandAction.Free;
                    //disable staff light
                }
                break;
        }
	}
}
