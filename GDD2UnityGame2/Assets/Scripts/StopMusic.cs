using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {
		if (gameObject.GetComponent<GlowObject>().glowing == true)
        {
            if (Input.GetKeyDown("e"))
                if (gameObject.GetComponent<AudioSource>().isPlaying == true)
                    gameObject.GetComponent<AudioSource>().Pause();
                else
                    gameObject.GetComponent<AudioSource>().Play();
        }
	}
}
