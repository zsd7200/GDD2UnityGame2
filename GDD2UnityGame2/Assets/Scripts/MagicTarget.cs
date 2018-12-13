using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType { Fuego, Ventiferro, Lumen, Dispertius, Resarcius, Door }
public class MagicTarget : MonoBehaviour
{
    public TargetType type;

    public void Activate()
    {
        switch (type)
        {
            case (TargetType.Fuego):

                break;
            case (TargetType.Ventiferro):

                break;
            case (TargetType.Lumen):

                break;
            case (TargetType.Dispertius):
                type = TargetType.Resarcius;
                break;
            case (TargetType.Resarcius):
                type = TargetType.Dispertius;
                break;
            case (TargetType.Door):
                type = TargetType.Resarcius;
                break;
        }
    }
}
