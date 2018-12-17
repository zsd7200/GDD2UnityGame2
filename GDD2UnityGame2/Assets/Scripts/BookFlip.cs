using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookFlip : MonoBehaviour {

    public int order;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Flip()
    {
        StartCoroutine(Rotate(gameObject, 5, Quaternion.Euler(0,45,30)));

    }


    // shrink animation for door and note
    private IEnumerator Rotate(GameObject obj, float delay, Quaternion rot)
    {
        float currTime = 0;

        while (currTime <= delay)
        {
            obj.transform.rotation = Quaternion.Lerp(obj.transform.rotation, rot, currTime / delay);
            currTime += Time.deltaTime;

            yield return null;
        }
    }
}
