using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject Player;
    public float resetPosX;
    public float resetPosY;
    // Start is called before the first frame update
    void Start()
    {
        resetPosX = Player.transform.position.x;
        resetPosY = Player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf == false)
            {
                pauseMenu.SetActive(true);
            }
            else
            {
                pauseMenu.SetActive(false);
            }
        }
    }

    public void Reset()
    {
        Player.transform.position = new Vector2(resetPosX, resetPosY);
        pauseMenu.SetActive(false);
    }
}
