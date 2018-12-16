using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour {

    public Animator anim;
    //public Rigidbody rBody;

    private float inputH;
    private float inputV;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        //rBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);


    }
}
