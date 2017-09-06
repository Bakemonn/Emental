using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultScript : MonoBehaviour {

    public int resultScore;
    public Text resultText;

	// Use this for initialization
	void Start () {
        resultScore = CameraScripts.getScore();        
	}
	
	// Update is called once per frame
	void Update () {
        resultText.text = "Score : " + resultScore.ToString();
	}

    public void TitleButton()
    {
        SceneManager.LoadScene("Title");
    }
}
