using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookFlip : MonoBehaviour {

    public int order;
    private Quaternion originalQuat;

	// Use this for initialization
	void Start () {
        originalQuat = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Flip()
    {
        StartCoroutine(Rotate(gameObject, 5, Quaternion.Euler(10, 90, 0)));
        StartCoroutine(Rotate(gameObject, 5, originalQuat));
    }

    public void ShelfFlip()
    {
        StartCoroutine(Translate(gameObject, 5, new Vector3(-23.32f, 0, -14.51f)));
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

    // shrink animation for door and note
    private IEnumerator Translate(GameObject obj, float delay, Vector3 pos)
    {
        float currTime = 0;

        while (currTime <= delay)
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position, pos, currTime / delay);
            currTime += Time.deltaTime;

            yield return null;
        }
    }
}
