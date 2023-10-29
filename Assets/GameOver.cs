using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject screenParent;
    public GameObject scoreParent;
    public UnityEngine.UI.Text loseText;
    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Image[] stars;

    // Start is called before the first frame update
    void Start()
    {
        screenParent.SetActive(false);

        for(int i = 0; i < stars.Length; i++)
        {
            stars[i].enabled = false;
            stars[i].gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().enabled = false;
            stars[i].gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Image>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowLose()
    {
        screenParent.SetActive(false);
        screenParent.SetActive(true);

        Animator animator = GetComponent<Animator>();
        if (animator)
        {
            animator.Play("GameOverShow");
        }
    }

    public void ShowWin(int score, int startCount)
    {
        screenParent.SetActive(true);
        loseText.enabled = false;

        scoreText.text = score.ToString();
        scoreText.enabled = false;

        Animator animator = GetComponent<Animator>();
        if (animator)
        {
            animator.Play("GameOverShow");
        }

        StartCoroutine(ShowWinCoroutine(startCount));
    }


    private IEnumerator ShowWinCoroutine(int starCount)
    {
        yield return new WaitForSeconds(0.5f);

        if(starCount < stars.Length)
        {
            for(int i = 0; i <= starCount; i++)
            {
                stars[i].enabled = true;
                stars[i].gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().enabled = true;
                stars[i].gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Image>().enabled = true;

                if(i > 0)
                {
                    stars[i - 1].enabled = false;
                    stars[i - 1].gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().enabled = false;
                    stars[i - 1].gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Image>().enabled = false;
                }

                yield return new WaitForSeconds(0.5f);
            }
        }

        scoreText.enabled = true;
    }


    public void OnReplayClicked()
    {
        if(PlayerPrefs.GetInt("Lives") > 0)
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void OnDoneClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("levelSelect");
    }
}
