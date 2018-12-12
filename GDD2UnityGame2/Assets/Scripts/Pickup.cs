using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType { Generic, Scroll, Dragon, Photo}
public class Pickup : MonoBehaviour {
    public PickupType type;
}
