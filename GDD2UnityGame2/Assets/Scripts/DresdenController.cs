using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public enum HandAction { Free, HoldObject, FlickumBicus}
public class DresdenController : MonoBehaviour
{
    public static Transform Dresden;
    //Reference items
    const KeyCode FlickumKey = KeyCode.E;
    const KeyCode MagicKey = KeyCode.F;
    public const float interactDist = 5f; //Maximum pickup distance
    [SerializeField] Texture2D crosshair; // crosshair image
    [SerializeField] GameObject selfLight;

    //Variables
    HandAction handAction;
    GameObject held = null;
    [SerializeField] RaycastHit hit;
    
    public bool IsHolding(PickupType item)
    {
        return handAction == HandAction.HoldObject && held.GetComponent<Pickup>().type == item;
    }
    public GameObject HeldItem
    {
        get { return held; }
    }

    // Use this for initialization
    void Start () {
        if (Dresden == null) Dresden = transform;
	}
	
	// Update is called once per frame
	void Update ()
    {

        //Checks for interactions
        Ray ray = Camera.main.ScreenPointToRay(new Vector3((Screen.width / 2) - (crosshair.width / 2), (Screen.height / 2) - (crosshair.height / 2), 0));
        //Debug.Log(ray);
        if (Physics.Raycast(ray, out hit, interactDist) && hit.transform.gameObject != gameObject)
        {
            Debug.Log(hit.transform);
            
            GlowObject getGlow = hit.transform.GetComponent<GlowObject>();
            if (getGlow != null)
            {
                getGlow.OnGlowEnter();
                getGlow.timer = 0;
            }

            if(Input.GetMouseButtonDown(0)) //Left-clicking on object
            {
                if (hit.transform.GetComponent<Pickup>() != null) //Item can be picked up
                {
                    if(handAction == HandAction.HoldObject) //Swaps currently held object
                    {
                        held.transform.parent = null;
                        held.transform.position = hit.transform.position;
                    }
                    held = hit.transform.gameObject;

                    held.transform.position = transform.position + new Vector3(Mathf.Cos(Mathf.Deg2Rad * (transform.rotation.eulerAngles.y - 5)), transform.position.y + 1.76f, Mathf.Sin(Mathf.Deg2Rad * (transform.rotation.eulerAngles.y - 5)));
                    held.transform.parent = transform;

                    handAction = HandAction.HoldObject;
                }

                Popup popupItem = hit.transform.GetComponent<Popup>();
                if (handAction == HandAction.Free && popupItem != null && popupItem.enabled) popupItem.DrawPopup();
            }
            if (Input.GetKeyDown(MagicKey))//Use magic
            {
                MagicTarget MagicItem = hit.transform.GetComponent<MagicTarget>();
                if (MagicItem != null && MagicItem.enabled) MagicItem.Activate();
            }
            if (handAction != HandAction.FlickumBicus && Input.GetKeyDown(FlickumKey)){ //Light stuff on fire
                LightCandle getLight = hit.transform.GetComponent<LightCandle>();
                if (getLight != null && getLight.enabled) getLight.LightFlame();
            }
        }

        //Other updates
        else if(Input.GetKeyDown(FlickumKey))
        {
            if(handAction == HandAction.Free)
            {
                selfLight.SetActive(true);
                handAction = HandAction.FlickumBicus;
            }
            if(handAction == HandAction.FlickumBicus)
            {
                selfLight.SetActive(false);
                handAction = HandAction.Free;
            }
        }

        if (handAction == HandAction.HoldObject)
        {
            if (held == null) handAction = HandAction.Free; //Failsafe
            if (Input.GetMouseButtonDown(1))
            {
                held.transform.parent = null;
                held.transform.position = new Vector3(held.transform.position.x, 0, held.transform.position.z);
                held = null;
                handAction = HandAction.Free;
            }
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
