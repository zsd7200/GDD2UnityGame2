using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PopupType { Scroll, Book, Bookcase, Crack, Win }
public class Popup : MonoBehaviour
{
    public PopupType type;

    public void DrawPopup()
    {
        switch (type)
        {
            case (PopupType.Scroll):
                
                break;
            case (PopupType.Book):

                break;
            case (PopupType.Bookcase):

                break;
            case (PopupType.Crack):

                break;
            case (PopupType.Win): //WIN CONDITION
                //win
                return;
        }
    }
}
