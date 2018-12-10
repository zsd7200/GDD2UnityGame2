using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseUI;
    public GameObject fpsController;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (pauseUI.activeSelf == true)
                Resume();
            else
                Pause();
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        fpsController.GetComponent<FirstPersonController>().enabled = true;
        Time.timeScale = 1f;
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        fpsController.GetComponent<FirstPersonController>().enabled = false;
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
