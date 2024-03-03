using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void HowToPlayButton()
    {
        //Show how to play screen;
        SceneManager.LoadScene("HowtoPlay");
    }

    public void CreditButton()
    {
        //Show who did what and if we used any assets that are not ours;
        SceneManager.LoadScene("Credit");
    }
    public void HighscoreButton()
    {
        //Show highscores;
        SceneManager.LoadScene("HighScores");
    }
    public void BackButton()
    {
        //Show highscores;
        SceneManager.LoadScene("StartScene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
