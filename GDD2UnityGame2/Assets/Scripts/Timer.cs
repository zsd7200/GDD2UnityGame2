using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    float timeRemaining; //Actual Time left in seconds
    int minRemaining; //minutes remaining
    int secondsRemaining; //Rounded up
    public static string formattedTime; //String to hold time

	// Use this for initialization
	void Start () {
        timeRemaining = 1800.0f; //30 minutes (30x60)
	}
	
	// Update is called once per frame
	void Update () {
        timeRemaining -= Time.deltaTime;
        secondsRemaining = (int)(timeRemaining % 60); //Find the number of seconds remaining
        minRemaining = (int)(timeRemaining / 60);//Find the number of minutes remaining

        formattedTime = minRemaining + ":" + secondsRemaining; //Formatted time
        Debug.Log(formattedTime);

    }
}
