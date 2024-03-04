using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreTable : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI time;
    public TextMeshProUGUI pos;

    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);


        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {

            for (int j = 0; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighScoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highScoreEntry in highscores.highscoreEntryList)
        {
            CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }
    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {

        float templateHeight = 40f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;

        pos.text = rank.ToString();

        float speedTime = highScoreEntry.score;

        time.text = speedTime.ToString();

        string name = highScoreEntry.name;
        playerName.text = name;

        transformList.Add(entryTransform);
    }

    public static void AddHighscoreEntry(float score, string name)
    {
        HighScoreEntry highscoreEntry = new HighScoreEntry { score = score, name = name};
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreEntryList.Add(highscoreEntry);
        string json = JsonUtility.ToJson(highscores); 
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores
    {
        public List<HighScoreEntry> highscoreEntryList;
    }

    [System.Serializable]

    private class HighScoreEntry
    {
        public float score;
        public string name;
    }
}
