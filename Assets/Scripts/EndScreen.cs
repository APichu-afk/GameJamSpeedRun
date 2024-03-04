using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI score;
    private void Awake()
    {
        score.text = Timer.playerScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Highscores()
    {
        SceneManager.LoadScene("HighScores");
    }
}
