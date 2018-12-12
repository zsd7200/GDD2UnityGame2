using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public enum HandAction { Free, HoldObject}
public class DresdenController : MonoBehaviour
{
    public static Transform Dresden;
    //Reference items
    const KeyCode FlickumKey = KeyCode.E;
    const KeyCode MagicKey = KeyCode.F;
    public const float interactDist = 5f; //Maximum pickup distance
    [SerializeField] Texture2D crosshair; // crosshair image

    //Variables
    HandAction handAction;
    GameObject held = null;
    [SerializeField] RaycastHit hit;

    // Use this for initialization
    void Start () {
        if (Dresden == null) Dresden = transform;
	}
	
	// Update is called once per frame
	void Update ()
    {

        //Checks for interactions
        Ray ray = Camera.main.ScreenPointToRay(new Vector3((Screen.width / 2) - (crosshair.width / 2), (Screen.height / 2) - (crosshair.height / 2), 0));
        if (Physics.Raycast(ray, out hit, 5))
        {
            Debug.Log(hit.transform);
            
            GlowObject getGlow = hit.transform.GetComponent<GlowObject>();
            if (getGlow != null)
            {
                getGlow.OnGlowEnter();
                getGlow.timer = 0;
            }

            if(handAction == HandAction.Free && Input.GetMouseButtonDown(0)) //Left-clicking on object
            {
                if(hit.transform.GetComponent<Pickup>() != null) //Item can be picked up
                {
                    held = hit.transform.gameObject;
                    handAction = HandAction.HoldObject;
                }
                if (false) //placeholder for puzzles
                {

                }
            }

            if (Input.GetKeyDown(FlickumKey)){ //Light stuff on fire
                LightCandle getLight = hit.transform.GetComponent<LightCandle>();
                if (getLight != null) getLight.LightFlame();
            }
        }

        //Other updates
        if (handAction == HandAction.HoldObject)
        {
            if (held == null) handAction = HandAction.Free; //Failsafe
            else held.transform.position = transform.position + new Vector3(Mathf.Cos(transform.rotation.eulerAngles.y),transform.position.y, Mathf.Sin(transform.rotation.eulerAngles.y));
        }
	}

    // draw crosshair
    void OnGUI()
    {
        // create style to have no border/bg
        GUIStyle style = new GUIStyle();
        style.border = new RectOffset(0, 0, 0, 0);

        // draw crosshair
        GUI.Box(new Rect((Screen.width / 2) - (crosshair.width / 2), (Screen.height / 2) - (crosshair.height / 2), crosshair.width, crosshair.height), crosshair, style);
    }
}
