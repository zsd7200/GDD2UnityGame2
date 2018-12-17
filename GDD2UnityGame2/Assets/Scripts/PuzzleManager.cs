using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour {
    const int totalCandles = 14;

    public int litCandles = 0;
    public int artifactCount = 0;

    [SerializeField] GameObject Fireplace;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (litCandles == totalCandles)
        {
            Vector3 scale = Fireplace.transform.GetChild(1).localScale;
            scale.x *= .1f;
            Fireplace.transform.GetChild(1).localScale = scale;
            Fireplace.GetComponent<GlowObject>().enabled = true;
            Fireplace.GetComponent<MagicTarget>().enabled = true;
            litCandles = -1;
            Fireplace.transform.GetChild(2).GetComponent<AudioSource>().Play();
        }
	}
}
