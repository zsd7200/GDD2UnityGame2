using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType { Scroll, Dragon, Photo}
public class Pickup : MonoBehaviour {
    public PickupType type;
    const float maxPickup = 1f; //Maximum pickup distance

    private void OnMouseDown()
    {
        if(Mathf.Abs(DresdenController.Dresden.position.magnitude - transform.position.magnitude) <= maxPickup)
        {

        }
    }
}
