using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour {

    public Animator anim;
    //public Rigidbody rBody;

    private float inputH;
    private float inputV;
    bool turnedRight;
    bool turnedLeft;
    bool ran;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        //rBody = GetComponent<Rigidbody>();
        turnedRight = false;
        turnedLeft = false;
        ran = false;
    }
	
	// Update is called once per frame
	void Update () {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

        //check to turn left or right
        if(((inputH > 0.1 && inputV > -0.1) || (inputH < -0.1 && inputV < -0.1)) && !turnedRight && !turnedLeft)
        {
            turnedRight = true;
            transform.Rotate(Vector3.up * 45);
        }
        else if (((inputH < -0.1 && inputV > -0.1) || (inputH > 0.1 && inputV < -0.1)) && !turnedLeft && !turnedRight)
        {
            turnedLeft = true;
            transform.Rotate(Vector3.down * 45);
        }

        if (inputH > -0.1 && inputH < 0.1)
        {
            if (turnedRight)
            {
                turnedRight = false;
                transform.Rotate(Vector3.down * 45);
            }
            else if (turnedLeft)
            {
                turnedLeft = false;
                transform.Rotate(Vector3.up * 45);
            }
        }

        //check to center running animation
        if ((inputV > 0.1 || inputV < -0.1) && !ran)
        {
            transform.Rotate(Vector3.down * 15);
            ran = true;
        }
        else if(inputV > -0.1 && inputV < 0.1 && ran)
        {
            transform.Rotate(Vector3.up * 15);
            ran = false;
        }
    }
}
