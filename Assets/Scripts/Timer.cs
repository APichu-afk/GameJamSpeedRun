using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI minuteText;

    public float currentTime;
    public bool countDown;
    public float minute;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        timerText.color = Color.green;
        minuteText.color = Color.green;

        if (currentTime >= 60)
        {
            currentTime = 0;
            minute += 1;
            minuteText.text = minute.ToString();
        }

        SetTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("00.000");
        minuteText.text = minute.ToString("0:");
    }
}
