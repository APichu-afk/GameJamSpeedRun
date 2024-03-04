using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf == false)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0.0f;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }
    }

    public void Reset()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SampleScene");
        pauseMenu.SetActive(false);
    }
}
