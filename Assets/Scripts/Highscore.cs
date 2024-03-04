using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System.Linq;

public class Highscore : MonoBehaviour
{
    public TextMeshProUGUI scoresText;
    public string scores;
    public string playerScore;
    private int top = 10;
    private int counter = 0;
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

        List<string>sortScores = new List<string>();
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            sortScores.Add(line);
        }
        sr.Close();

        sortScores.Sort();

        StreamWriter swSorted = new StreamWriter(path);

        foreach (string s in sortScores)
        {
            swSorted.WriteLine(s);
        }

        swSorted.Close();

        StreamReader srSorted = new StreamReader(path);

        while(counter < top)
        {
            scores = srSorted.ReadLine();
            scoresText.text += scores + "\n";
            counter++;
        }
        
        srSorted.Close();
        
    }
}
