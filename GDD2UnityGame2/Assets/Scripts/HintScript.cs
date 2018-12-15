using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class HintScript : MonoBehaviour
{

    [SerializeField] GameObject noteUI;
    [SerializeField] GameObject player;
    public GameObject note;
    public GameObject pauseUI;
    FirstPersonController fpsController;
    DresdenController playerController;

    private void Start()
    {
        fpsController = player.GetComponent<FirstPersonController>();
        playerController = player.GetComponent<DresdenController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && note.GetComponent<GlowObject>().glowing == true && pauseUI.activeSelf == false)
            if (noteUI.activeSelf)
                Resume();
            else
                Pause();
    }

    public void Resume()
    {
        noteUI.SetActive(false);
        fpsController.enabled = true;
        playerController.enabled = true;
        Time.timeScale = 1f;
    }

    void Pause()
    {
        noteUI.SetActive(true);
        fpsController.enabled = false;
        playerController.enabled = false;
        Time.timeScale = 0f;
    }
}
