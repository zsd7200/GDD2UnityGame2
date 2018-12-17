using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class WinLoseChecker : MonoBehaviour {

    public GameObject loseUI;
    public GameObject winUI;
    public GameObject player;
    FirstPersonController fpsController;
    DresdenController playerController;
    bool alreadyRun;

    private void Start()
    {
        fpsController = player.GetComponent<FirstPersonController>();
        playerController = player.GetComponent<DresdenController>();
        alreadyRun = false;
    }

    // Update is called once per frame
    void Update ()
    {
		if (Timer.formattedTime == "0:00")
            Pause(loseUI);

        if (loseUI.activeSelf == true && Input.GetKeyDown(KeyCode.X))
            Application.Quit();

        if (PuzzleManager.artifactCount == 4 && alreadyRun == false)
        {
            Pause(winUI);
            alreadyRun = true;
        }

        if (winUI.activeSelf == true && Input.GetKeyDown(KeyCode.Mouse0))
            Resume(winUI);
	}

    public void Resume(GameObject ui)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ui.SetActive(false);
        fpsController.enabled = true;
        playerController.enabled = true;
        Time.timeScale = 1f;
    }

    void Pause(GameObject ui)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        ui.SetActive(true);
        fpsController.enabled = false;
        playerController.enabled = false;
        Time.timeScale = 0f;
    }
}
