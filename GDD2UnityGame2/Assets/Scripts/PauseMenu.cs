using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseUI;
    public GameObject noteUI;
    FirstPersonController fpsController;
    DresdenController playerController;

    private void Start()
    {
        fpsController = DresdenController.Dresden.GetComponent<FirstPersonController>();
        playerController = DresdenController.Dresden.GetComponent<DresdenController>();
        //Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Popup.popupOn && !noteUI.activeSelf && Input.GetKeyDown(KeyCode.Escape))
            if (pauseUI.activeSelf)
                Resume();
            else
                Pause();
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        fpsController.enabled = true;
        playerController.enabled = true;
        Time.timeScale = 1f;
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        fpsController.enabled = false;
        playerController.enabled = false;
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Resume();
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
