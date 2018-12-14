using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType { Fuego, Ventiferro, Lumen, Dispertius, Resarcius, Door }
public class MagicTarget : MonoBehaviour
{
    public TargetType type;
    [SerializeField] GameObject reference1;
    [SerializeField] GameObject reference2;
    [SerializeField] GameObject reference3;

    public void Activate()
    {
        DresdenController dresden = DresdenController.Dresden.GetComponent<DresdenController>();
        switch (type)
        {
            case (TargetType.Fuego):
                reference1.SetActive(true);
                break;
            case (TargetType.Ventiferro):

                break;
            case (TargetType.Lumen):
                if(dresden.IsHolding(PickupType.Photo)) //Dresden is holding photo
                {

                }
                break;
            case (TargetType.Dispertius):
                type = TargetType.Resarcius;
                break;
            case (TargetType.Resarcius):
                type = TargetType.Dispertius;
                break;
            case (TargetType.Door):
                if (PuzzleManager.artifactCount == 5) gameObject.GetComponent<Popup>().enabled = true;
                break;
        }
    }

    private void Start()
    {
        if (false) enabled = false; //Referencing enabled makes it appear in the inspector, so we can pick which ones are active at first
    }
}
