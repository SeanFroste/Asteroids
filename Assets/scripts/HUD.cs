using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Displays the Score
/// </summary>
public class HUD : MonoBehaviour
{
    [SerializeField]
    Text scoreText;

    float timeElapsed = 0;
    bool timerRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
       if (timerRunning)
        {
            timeElapsed += Time.deltaTime;
            scoreText.text = ((int)timeElapsed).ToString();
        }
    }

    public void StopGameTimer()
    {
        timerRunning = false;
    }
}
