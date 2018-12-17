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
    public GameObject dresdenModel;
    private Vector3 v,vv,vvv;
    bool[] corout = new bool[5];

    public TargetType type;
    [SerializeField] GameObject reference1; //Used during activation
    [SerializeField] GameObject reference2;
    [SerializeField] GameObject reference3;
    bool hole = false;
    bool lit = false;
    bool reflect = false;

    public void Activate()
    {
        DresdenController dresden = DresdenController.Dresden.GetComponent<DresdenController>(); //Find player script

        switch (type)
        {
            //sets fire to the fireplace
            case (TargetType.Fuego):
                if (hole == false)
                {
                    reference1.SetActive(true);
                    lit = true;
                }
                break;
            case (TargetType.Ventiferro):
                gameObject.GetComponent<Popup>().enabled = true;
                gameObject.GetComponent<Popup>().DrawPopup();
                break;
            case (TargetType.Lumen):
                if(dresden.IsHolding(PickupType.Photo)) //Dresden is holding photo
                {
                    if (reflect == false)
                    {
                        //reference1.SetActive(true);
                        reflect = true;

                        if (dresdenModel.activeSelf == true)
                            dresdenModel.SetActive(false);
                        else
                            dresdenModel.SetActive(true);
                    }
                }
                break;
                //crack
            case (TargetType.Dispertius):
                if (hole == false)
                {
                    reference1.SetActive(true);
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

    private void Update()
    {
        if (hole == true)
        {
            if (corout[0] == true)
            {
                StartCoroutine(MoveAnim(rune1, 2, v));
                //rune1.transform.GetChild(0).GetComponent<AudioSource>().Play();
            }
            corout[0] = false;

            if (rune1.activeSelf == true && rune1.GetComponent<AlwaysGlow>().glow == false)
                rune1.GetComponent<AlwaysGlow>().glow = true;
        }


        if (lit == true)
        {
            if (corout[1] == true)
            {
                StartCoroutine(MoveAnim(rune2, 2, vv));
                rune2.transform.GetChild(0).GetComponent<AudioSource>().Play();
            }


            corout[1] = false;

            if (rune2.activeSelf == true && rune2.GetComponent<AlwaysGlow>().glow == false)
                rune2.GetComponent<AlwaysGlow>().glow = true;
        }

        if (reflect == true)
        {
            if (corout[2] == true)
            {
                StartCoroutine(MoveAnim(rune3, 2, vvv));
                rune3.transform.GetChild(0).GetComponent<AudioSource>().Play();
            }


            corout[2] = false;

            if (rune3.activeSelf == true && rune3.GetComponent<AlwaysGlow>().glow == false)
                rune3.GetComponent<AlwaysGlow>().glow = true;
        }




    }

    private void Start()
    {
        //if (false) enabled = false; //Referencing enabled makes it appear in the inspector, so we can pick which ones are active at first
        rune1 = GameObject.FindGameObjectWithTag("rune1");
        rune2 = GameObject.FindGameObjectWithTag("rune2");
        rune3 = GameObject.FindGameObjectWithTag("rune3");
        rune4 = GameObject.FindGameObjectWithTag("rune4");
        rune5 = GameObject.FindGameObjectWithTag("rune5");

        v = rune1.transform.position;
        v.y = 2f;

        vv = rune2.transform.position;
        vv.z = -22f;

        vvv = rune3.transform.position;
        vvv.z = 2f;

        for (int i = 0; i < corout.Length; i++)
        {
            corout[i] = true;
        }
    }

    // movement animation
    private IEnumerator MoveAnim(GameObject obj, float delay, Vector3 newPos)
    {
       

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
