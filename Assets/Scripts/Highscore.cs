using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class Highscore : MonoBehaviour
{
    public TextMeshProUGUI scoresText;
    public string scores;
    public string playerScore;
    private string path = @".\Highscores.txt";
    private void Awake()
    {
        playerScore = Timer.playerScore;

        StreamWriter sw = new StreamWriter(path, true);

        if (playerScore != null)
        {
            sw.WriteLine(playerScore);
            
        }

        sw.Close();

        StreamReader sr = new StreamReader(path);
        scores = sr.ReadToEnd();
        scoresText.text = scores;
        sr.Close();
    }
}
