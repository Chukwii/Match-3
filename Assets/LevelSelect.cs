using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [System.Serializable]
    public struct ButtonPlayerPrefs
    {
        public GameObject gameObject;
        public string playerPrefKey;
    }

    public ButtonPlayerPrefs[] buttons;
    public Text hTxt;
    public int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Lives", lives);
        lives = PlayerPrefs.GetInt("Lives");

        for (int i = 0; i < buttons.Length; i++)
        {
            int score = PlayerPrefs.GetInt(buttons[i].playerPrefKey, 0);

            for(int starIdx = 1; starIdx <= 3; starIdx++)
            {
                Transform star = buttons[i].gameObject.transform.Find("star" + starIdx);

                if(starIdx <= score)
                {
                    star.gameObject.SetActive(true);
                }
                else
                {
                    star.gameObject.SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        hTxt.text = lives.ToString();
        PlayerPrefs.SetInt("Lives", lives);
    }

    public void OnButtonPress(string levelName)
    {
        if(PlayerPrefs.GetInt("Lives") > 0)
            UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
}
