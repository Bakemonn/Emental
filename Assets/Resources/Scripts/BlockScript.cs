using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

    public bool Del;
    public bool Now;
    public Touch touch;
    public bool Active;
    public bool ActiveDel;
    private int plusScore = 0;

    // Use this for initialization
    void Start () {
        Del = false;
        Active = false;
        ActiveDel = false;
        Now = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount == 0)
        {
            if (Del)
            {
                CameraScripts.score += plusScore;
                plusScore = 0;
                GameController.Bonus = 0;
                Destroy(this.gameObject);
            }

            if (ActiveDel)
            {
                Destroy(this.gameObject);
            }

            
        }
	}

    public void ActiveBlock()
    {
        Active = true;
    }

    public void ActiveDelBlock()
    {
        ActiveDel = true;
    }

    public void ReadyBlock(int Bonus)
    {
        if (!Del)
        {
            Color color = gameObject.GetComponent<Renderer>().material.color;
            color += new Color(-3, -3, -3);
            gameObject.GetComponent<Renderer>().material.color = color;

            plusScore += (5 + Bonus);
            GameController.Bonus++;
            Debug.Log(plusScore);
            Debug.Log(Bonus);
        }
        Del = true;
    }
}
