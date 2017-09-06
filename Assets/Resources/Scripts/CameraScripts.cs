using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraScripts : MonoBehaviour {

    public Text scoreText;
    public static int score = 0;

    public Text timeText;
    private float time = 10.0f;
    

    void GameOver()
    {
        timeText.enabled = false;
        scoreText.enabled = false;

        SceneManager.LoadScene("Result");
    }

	// Use this for initialization
	void Start () {
        score = 0;
        scoreText.text = "Score:0";
        timeText.text = "Time:60.0";
    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;

        scoreText.text = "Score:" + score.ToString();
        timeText.text = "Time:" + time.ToString("F1");
        if(time <= 0)
        {
            GameOver();
        }
	}

    public static int getScore()
    {
        return score;
    }
}
