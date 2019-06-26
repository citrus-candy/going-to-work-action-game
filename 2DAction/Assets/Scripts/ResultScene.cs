using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScene : MonoBehaviour {

   // public GameController gameController;
    public GameObject ResultScore;
    public GameObject NewRecord;

    private float myTime;
    protected static float highTime = 0f;

	// Use this for initialization
	void Start () {
        myTime = GameController.ToTime();
        ResultScore.GetComponent<Text>().text = myTime.ToString("f1") + " びょう";

        if (highTime == 0)
        {
            highTime = myTime;
            NewRecord.SetActive(false);
        }
        else if (highTime > myTime)
        {
            highTime = myTime;
            NewRecord.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleScene");
        }

    }

    public static float ToScore()
    {
        return highTime;
    }
}
