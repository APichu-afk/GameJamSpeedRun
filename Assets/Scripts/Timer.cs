using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI minuteText;

    public float currentTime;
    public bool countDown;
    public float minute;

    public bool stopped = false;
    private void Start()
    {
        timerText.color = Color.green;
        minuteText.color = Color.green;
    }
    void Update()
    {
        if (stopped == false)
        {
            currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        }



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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            stopped = true;
            timerText.color = Color.red;
            minuteText.color = Color.red;
            
            SceneManager.LoadScene("Final");
        }
    }
}
