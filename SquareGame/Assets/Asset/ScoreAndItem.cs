using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndItem : MonoBehaviour
{
    public float timerInSeconds;
    float totalTime = 60f; //1 minutes
    public Text timer; 

    private void Update()
    {
        if (StateManager.state.score == 0)
        {
            StateManager.state.startTimer = true;
            totalTime = timerInSeconds;
        }
        if (StateManager.state.startTimer)
        {
            totalTime -= Time.deltaTime;
            if(totalTime < 0)
            {
                StateManager.state.startTimer = false;
                StateManager.state.enableInput = false;
                return;
            }
            UpdateLevelTimer(totalTime);
        }
    }

    public void UpdateLevelTimer(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        timer.text = minutes.ToString("0") + ":" + seconds.ToString("00");
    }
}
