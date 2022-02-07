using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    float timeValue;
    public bool startTimer;
    public TMP_Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        startTimer = false;
    }

    public void StartCounting()
    {
        startTimer = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(startTimer == true)
        {
            timeValue += Time.deltaTime;

            float minutes = Mathf.FloorToInt(timeValue / 60);
            float seconds = Mathf.FloorToInt(timeValue % 60);

            timerText.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));

        }
    }
}
