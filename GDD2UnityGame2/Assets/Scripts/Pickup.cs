using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType { Generic, Scroll, Dragon, Photo}
public class Pickup : MonoBehaviour {
    public PickupType type;

    private void Start()
    {
        if (false) enabled = false; //Referencing enabled makes it appear in the inspector, so we can pick which ones are active at first
    }
}
