using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

//public enum PopupType { Scroll, Book, Bookcase, Crack, Win }

public class Popup : MonoBehaviour
{
    public static bool popupOn = false;

    //public PopupType type;
    [SerializeField] GameObject canvas;
    FirstPersonController fpsController;
    DresdenController playerController;

    private void Start()
    {
        fpsController = DresdenController.Dresden.GetComponent<FirstPersonController>();
        playerController = DresdenController.Dresden.GetComponent<DresdenController>();
        if (false) enabled = false; //Referencing enabled makes it appear in the inspector, so we can pick which ones are active at first
    }

    public void DrawPopup()
    {
        canvas.SetActive(true);
        fpsController.enabled = false;
        playerController.enabled = false;
        popupOn = true;
    }
    public void RemovePopup()
    {
        canvas.SetActive(false);
        fpsController.enabled = true;
        playerController.enabled = true;
        popupOn = false;
    }

    private void Update()
    {
        if (canvas.activeSelf && Input.GetKeyDown(KeyCode.Escape)) RemovePopup();
    }
}
