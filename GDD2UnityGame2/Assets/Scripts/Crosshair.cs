using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Texture2D crosshair; // crosshair image

    public RaycastHit hit;


	// Update is called once per frame
	void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3((Screen.width / 2) - (crosshair.width / 2), (Screen.height / 2) - (crosshair.height / 2), 0));


        if (Physics.Raycast(ray, out hit, 10))
        {
            //Debug.Log("touched book");
            Debug.Log(hit.transform);
            //GlowObject getGlow = null;
            //getGlow = hit.transform.GetComponent<GlowObject>();
            //if(getGlow != null)
            //{
            //    hit.transform.GetComponent<GlowObject>().enabled = true;
            //}

            GlowObject getGlow = null;
            getGlow = hit.transform.GetComponent<GlowObject>();
            if (getGlow != null)
            {
                getGlow.OnGlowEnter();
            }
            else
            {
                getGlow.OnGlowExit();
            }

        }
        //Debug.DrawRay(cameraOrigin, Camera.main.transform.rotation.eulerAngles, Color.red);
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
