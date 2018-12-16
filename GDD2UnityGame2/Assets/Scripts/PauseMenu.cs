using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject player;
    public GameObject noteUI;
    public GameObject note;
    public GameObject pauseAfterNoteUI;
    FirstPersonController fpsController;
    DresdenController playerController;

    private void Start()
    {
        fpsController = player.GetComponent<FirstPersonController>();
        playerController = player.GetComponent<DresdenController>();
        //Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        // if note is still on door
        if (note.activeSelf)
        {
            // if note is glowing, read note, then destroy note and door
            if (Input.GetKeyDown(KeyCode.E) && note.GetComponent<GlowObject>().glowing == true && pauseUI.activeSelf == false)
                if (noteUI.activeSelf)
                    Disappear();
                else
                    Pause(noteUI);

            // if escape is pressed and the note is not active, display basic pause menu
            if (Input.GetKeyDown(KeyCode.Escape) && noteUI.activeSelf == false)
                if (pauseUI.activeSelf)
                    Resume(pauseUI);
                else
                    Pause(pauseUI);
        }

        // if note and door have been destroyed
        else
        {
            // display pause after receiving a note
            if (Input.GetKeyDown(KeyCode.Escape) && noteUI.activeSelf == false)
                if (pauseAfterNoteUI.activeSelf)
                    Resume(pauseAfterNoteUI);
                else
                    Pause(pauseAfterNoteUI);
            
            // if q is pressed, open note
            if (Input.GetKeyDown(KeyCode.Q))
                if (noteUI.activeSelf)
                    Resume(noteUI);
                else
                    Pause(noteUI);
        }

        // key to quit game
        if (Input.GetKeyDown(KeyCode.X) && (pauseUI.activeSelf == true || pauseAfterNoteUI.activeSelf == true))
            Application.Quit();

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

    void Disappear()
    {
        Resume(noteUI);
        note.SetActive(false);
        StartCoroutine(Shrink(GameObject.FindGameObjectWithTag("Door"), 5, Vector3.zero));
        //StartCoroutine(Shrink(note, 5, Vector3.zero));
    }

    // shrink animation for door and note
    private IEnumerator Shrink(GameObject obj, float delay, Vector3 scale)
    {
        float currTime = 0;

        while (currTime <= delay)
        {
            obj.transform.localScale = Vector3.Lerp(obj.transform.localScale, scale, currTime / delay);
            currTime += Time.deltaTime;

            yield return null;
        }
    }
}
