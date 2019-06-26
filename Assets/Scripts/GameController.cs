using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject GameOver;
    public GameObject Title;
    public GameObject PtoS;
    public GameObject HP_1;
    public GameObject HP_2;
    public GameObject HP_3;
    public GameObject HP_4;
    public GameObject Life;
    public GameObject Fukidashi;
    public GameObject CountText;
    public GameObject HighScore;

    public PlayerController playerController;

    public bool gameStart = false;
    private bool gameCount = false;
    private int playCount;
    private bool fukidashiFlag = false;

    public float totalTime;
    public float ScoreTime = 0f;
    protected static float resultTime;
    int seconds;
    Scene loadScene;

    // Use this for initialization
    void Start () {
        float highscore = ResultScene.ToScore();

        Title.SetActive(true);
        PtoS.SetActive(true);
        HighScore.SetActive(true);
        HighScore.GetComponent<Text>().text = "さいそく：" + highscore.ToString("f1") + " びょう";

        GameOver.SetActive(false);
        HP_1.SetActive(false);
        HP_2.SetActive(false);
        HP_3.SetActive(false);
        HP_4.SetActive(false);
        Life.SetActive(false);

        loadScene = SceneManager.GetActiveScene();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            Title.SetActive(false);
            PtoS.SetActive(false);
            HighScore.SetActive(false);
            gameCount = true;
        }

        if (gameCount)
        {
            if (!fukidashiFlag)
            {
                Fukidashi.SetActive(true);
            }
            Invoke("Count", 3.0f);

        }

        if (gameStart)
        {
            LifeDisplay(playerController.life);
            ScoreTime += Time.deltaTime;
        }

        if(playerController.GoalText)
        {
            GameOver.SetActive(true);
            GameOver.GetComponent<Text>().text = "ゴール！";
            gameStart = false;
            resultTime = ScoreTime;
            Invoke("ToResultScene", 5.0f);
        }

        if (playerController.noInput)
        {
            SceneManager.LoadScene(loadScene.name);
        }
    }

    void LifeDisplay(int life)
    {
        Life.SetActive(true);
        switch (life)
        {
            case 4:
                {
                    HP_1.gameObject.SetActive(true);
                    HP_2.gameObject.SetActive(true);
                    HP_3.gameObject.SetActive(true);
                    HP_4.gameObject.SetActive(true);
                    break;
                }
            case 3:
                {
                    HP_1.gameObject.SetActive(false);
                    HP_2.gameObject.SetActive(true);
                    HP_3.gameObject.SetActive(true);
                    HP_4.gameObject.SetActive(true);
                    break;
                }
            case 2:
                {
                    HP_1.gameObject.SetActive(false);
                    HP_2.gameObject.SetActive(false);
                    HP_3.gameObject.SetActive(true);
                    HP_4.gameObject.SetActive(true);
                    break;
                }
            case 1:
                {
                    HP_1.gameObject.SetActive(false);
                    HP_2.gameObject.SetActive(false);
                    HP_3.gameObject.SetActive(false);
                    HP_4.gameObject.SetActive(true);
                    break;
                }
            case 0:
                {
                    GameOver.SetActive(true);
                    gameStart = false;

                    HP_1.gameObject.SetActive(false);
                    HP_2.gameObject.SetActive(false);
                    HP_3.gameObject.SetActive(false);
                    HP_4.gameObject.SetActive(false);
                    Life.gameObject.SetActive(false);

                    Invoke("LoadScene", 5.0f);
                    break;
                }
        }
    }

    void Count()
    {
        Fukidashi.SetActive(false);
        fukidashiFlag = true;

        if (seconds > 0)
        {
            CountText.SetActive(true);
        }
        else if(seconds == 0)
        {
            CountText.GetComponent<Text>().text = "スタート！";
        }
        else
        {
            gameStart = true;
            CountText.SetActive(false);
        }

        totalTime -= Time.deltaTime;
        seconds = (int)totalTime;
        CountText.GetComponent<Text>().text = seconds.ToString();
    }
    
    void LoadScene()
    {
        SceneManager.LoadScene(loadScene.name);
    }

    void ToResultScene()
    {
        SceneManager.LoadScene("Result");
    }

    public static float ToTime()
    {
        return resultTime;
    }
}
