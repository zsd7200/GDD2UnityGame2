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
    [SerializeField] GameObject player;
    FirstPersonController fpsController;
    DresdenController playerController;

    private void Start()
    {
        fpsController = player.GetComponent<FirstPersonController>();
        playerController = player.GetComponent<DresdenController>();
        if (false) enabled = false; //Referencing enabled makes it appear in the inspector, so we can pick which ones are active at first
    }

    public void DrawPopup()
    {
        popupOn = true;
        canvas.SetActive(true);
        fpsController.enabled = false;
        playerController.enabled = false;
    }
    public void RemovePopup()
    {
        popupOn = false;
        canvas.SetActive(false);
        fpsController.enabled = true;
        playerController.enabled = true;
    }

    private void Update()
    {
        if (canvas.activeSelf && Input.GetKeyDown(KeyCode.Escape)) RemovePopup();
    }
}
