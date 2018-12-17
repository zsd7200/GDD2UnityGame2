using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject pauseUI;
    public GameObject noteUI;
    public GameObject note;
    public GameObject pauseAfterNoteUI;
    public GameObject glowDoor;
    public GameObject youWin;
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
            if (!pauseUI.activeSelf && note.activeSelf == true && Input.GetMouseButtonDown(0))
                if (noteUI.activeSelf)
                    Disappear();
                else
                    Pause(noteUI);

            // if escape is pressed and the note is not active, display basic pause menu
            if (!noteUI.activeSelf && Input.GetKeyDown(KeyCode.Escape))
                if (pauseUI.activeSelf)
                    Resume(pauseUI);
                else
                    Pause(pauseUI);
        }

        // if note and door have been destroyed
        else
        {
            // display pause after receiving a note
            if (!noteUI.activeSelf && Input.GetKeyDown(KeyCode.Escape))
                if (pauseAfterNoteUI.activeSelf)
                    Resume(pauseAfterNoteUI);
                else
                    Pause(pauseAfterNoteUI);

            // if q is pressed, open note
            if (!pauseUI.activeSelf && Input.GetKeyDown(KeyCode.Q))
                if (noteUI.activeSelf && pauseAfterNoteUI.activeSelf)
                {
                    Resume(noteUI);
                    Pause(pauseAfterNoteUI);
                }
                else if (noteUI.activeSelf)
                    Resume(noteUI);
                else
                    Pause(noteUI);
        }

        // key to quit game
        if (Input.GetKeyDown(KeyCode.X) && (pauseUI.activeSelf == true || pauseAfterNoteUI.activeSelf == true))
            Application.Quit();

        
        if(Input.GetKeyDown(KeyCode.Mouse0) && Wall.canClick == true && PuzzleManager.artifactCount == 4)
        {
            StartCoroutine(Shrink(GameObject.FindGameObjectWithTag("GlowDoor"), 5, new Vector3(1.229f, 1.229f, 1.229f)));
        }

        if (GameObject.FindGameObjectWithTag("GlowDoor").transform.localScale == new Vector3(1.229f, 1.229f, 1.229f))
            glowDoor.GetComponent<AlwaysGlow>().glow = true;

        if (glowDoor.GetComponent<AlwaysGlow>().glow == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Pause(youWin);
        }

        if (youWin.activeSelf == true && Input.GetKeyDown(KeyCode.X))
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
