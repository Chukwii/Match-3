using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{

    public float timeLeft = 180; 
    public Text countdownText;



    private void Update()
    {
        timeLeft = PlayerPrefs.GetFloat("timeLeft", timeLeft);
        if(PlayerPrefs.GetInt("Lives") < 3)
        {
            countdownText.gameObject.SetActive(true);
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTime();
            }
            else
            {
                if(GameObject.FindObjectOfType<HUD>() != null)
                    GameObject.FindObjectOfType<HUD>().livesSub++;
                if (GameObject.FindObjectOfType<LevelSelect>() != null)
                    GameObject.FindObjectOfType<LevelSelect>().lives++;

                timeLeft = 120;
            }
        }
        else
        {
            countdownText.gameObject.SetActive(false);
            timeLeft = 120;
        }
        PlayerPrefs.SetFloat("timeLeft", timeLeft);
    }


    private void updateTime()
    {
        //int hours = (int)(time / 3600);
        int minutes = (int)((timeLeft % 3600) / 60);
        int seconds = (int)(timeLeft % 60);
        //return string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
