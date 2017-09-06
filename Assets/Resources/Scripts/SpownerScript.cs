using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownerScript : MonoBehaviour {

    public GameObject Red;
    public GameObject Blue;
    public GameObject Green;

    int Rnd;

    // Use this for initialization
    void Start () {
        Rnd = Random.Range(0, 3);
        switch (Rnd)
        {
            case 0:
                MakeRed();
                break;
            case 1:
                MakeBlue();
                break;
            case 2:
                MakeGreen();
                break;
        }
    }
	

    private void OnTriggerExit(Collider other)
    {
        Rnd = Random.Range(0, 3);
        switch (Rnd)
        {
            case 0:
                MakeRed();
                break;
            case 1:
                MakeBlue();
                break;
            case 2:
                MakeGreen();
                break;
        }
    }

    void MakeRed()
    {
        GameObject red;
        red = Instantiate(Red, transform.position, Quaternion.identity);
        red.name = "Red";
    }
    void MakeBlue()
    {
        GameObject blue;
        blue = Instantiate(Blue, transform.position, Quaternion.identity);
        blue.name = "Blue";
    }
    void MakeGreen()
    {
        GameObject green;
        green = Instantiate(Green, transform.position, Quaternion.identity);
        green.name = "Green";
    }
}
