using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCandle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.GetChild(0).gameObject.SetActive(false); //Extinguish flame
	}
	
	// Update is called once per frame
	void Update () {
        //LightFlame();
    }

    public void LightFlame()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        if(transform.gameObject.GetComponent<Pickup>() == null) PuzzleManager.litCandles++; //Increments candle counter only if it's a static candle (aka not the dragon statue)
        this.enabled = false; //Prevents lighting a lit candle
    }

}
