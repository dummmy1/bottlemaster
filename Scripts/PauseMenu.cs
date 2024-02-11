using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject pauseMenu;
    private static bool cursorLocked = true;
    void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetButtonUp("Cancel"))
            if (gamePaused == false)
            {
                Time.timeScale = 0;
                gamePaused = true;
                //Cursor.visible = true;
                pauseMenu.SetActive(true);
            }
            else
            {
                pauseMenu.SetActive(false);
               //Cursor.visible = false;
                gamePaused = false;
                Time.timeScale = 1;
            }
        UpdateCursorLock();
    }
    void UpdateCursorLock()
    {
        if (cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLocked = false;
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLocked = true;
            }
        }
    }
}