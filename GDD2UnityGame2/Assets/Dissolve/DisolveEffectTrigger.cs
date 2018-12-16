using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisolveEffectTrigger : MonoBehaviour {


    public Material disolveMaterial;
    public float speed, max;
    private float currentY, startTime;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(currentY < max)
        {
            disolveMaterial.SetFloat("_DisolveY", currentY);
            currentY += Time.deltaTime * speed;
        }
	}
}
