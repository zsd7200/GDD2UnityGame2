using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType { Fuego, Ventiferro, Lumen, Dispertius, Resarcius, Solvos }
public class MagicTarget : MonoBehaviour
{
    public GameObject rune1;
    public GameObject rune2;
    public GameObject rune3;
    public GameObject rune4;
    public GameObject rune5;

    public TargetType type;
    [SerializeField] GameObject reference1;
    [SerializeField] GameObject reference2;
    [SerializeField] GameObject reference3;
    bool hole = false;

    public void Activate()
    {
        DresdenController dresden = DresdenController.Dresden.GetComponent<DresdenController>();

        switch (type)
        {
            case (TargetType.Fuego):
                reference1.SetActive(true);
                break;
            case (TargetType.Ventiferro):
                gameObject.GetComponent<Popup>().enabled = true;
                gameObject.GetComponent<Popup>().DrawPopup();
                break;
            case (TargetType.Lumen):
                if(dresden.IsHolding(PickupType.Photo)) //Dresden is holding photo
                {

                }
                break;
                //crack
            case (TargetType.Dispertius):
                if (hole == false)
                {
                    reference1.SetActive(true);
                    gameObject.SetActive(false);

                    Debug.Log(rune1.name);

                    Debug.Log(rune1.transform.position.x);
                    Debug.Log(rune1.transform.position.y);
                    Debug.Log(rune1.transform.position.z);

                    Vector3 v = rune1.transform.position;
                    v.y = .1f;

                    Debug.Log(v.x);
                    Debug.Log(v.y);
                    Debug.Log(v.z);

                    CoroutineHandler(rune1, 5, v);

                    Debug.Log(rune1.transform.position.x);
                    Debug.Log(rune1.transform.position.y);
                    Debug.Log(rune1.transform.position.z);

                    hole = true;
                }
                break;
            case (TargetType.Resarcius):
                if (hole == true)
                {
                    reference1.SetActive(true);
                    gameObject.SetActive(false);
                    hole = false;
                }
                break;
            case (TargetType.Solvos):
                if (PuzzleManager.artifactCount == 5) gameObject.GetComponent<Popup>().enabled = true;
                break;
        }
        Debug.Log("Dresden casts " + type + "!");
    }

    private void Start()
    {
        if (false) enabled = false; //Referencing enabled makes it appear in the inspector, so we can pick which ones are active at first
        rune1 = GameObject.FindGameObjectWithTag("rune1");
        rune2 = GameObject.FindGameObjectWithTag("rune2");
        rune3 = GameObject.FindGameObjectWithTag("rune3");
        rune4 = GameObject.FindGameObjectWithTag("rune4");
        rune5 = GameObject.FindGameObjectWithTag("rune5");

    }

    private void CoroutineHandler(GameObject obj, float delay, Vector3 newPos)
    {
        Debug.Log("handler");
        StartCoroutine(MoveAnim(obj, delay, newPos));
    }

    // movement animation
    private IEnumerator MoveAnim(GameObject obj, float delay, Vector3 newPos)
    {
        Debug.Log("move");

        float currTime = 0;
        Vector3 start = obj.transform.position;

        while (currTime <= delay)
        {
            obj.transform.position = Vector3.Lerp(start, newPos, currTime / delay);
            currTime += Time.deltaTime;

            if (currTime > delay)
                obj.transform.position = newPos;

            yield return null;
        }
    }

}
