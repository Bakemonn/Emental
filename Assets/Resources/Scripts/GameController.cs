using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public enum Block
    {
        No, Red, Blue, Green, UnKnown
    };
    public Block ActiveBlock;
    public Touch touch;

    BlockScript Blsc;

    public GameObject fire;
    public GameObject water;
    public GameObject wind;


    public static int Bonus = 0;


    // Use this for initialization
    void Start () {
        ActiveBlock = Block.No;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            /*-----------クリックしたオブジェクトを取得-----------*/
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.collider.gameObject.name);
                    if (hit.collider.gameObject.name == "Red")
                    {
                        ActiveBlock = Block.Red;
                        hit.collider.gameObject.SendMessage("ActiveBlock");
                    }
                    else if (hit.collider.gameObject.name == "Blue")
                    {
                        ActiveBlock = Block.Blue;
                        hit.collider.gameObject.SendMessage("ActiveBlock");
                    }
                    else if (hit.collider.gameObject.name == "Green")
                    {
                        ActiveBlock = Block.Green;
                        hit.collider.gameObject.SendMessage("ActiveBlock");
                    }
                }
            }
            if(touch.phase == TouchPhase.Moved)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit = new RaycastHit();
                Vector3 posi = Camera.main.ScreenToWorldPoint(touch.position);
                if (Physics.Raycast(ray, out hit))
                {
                    switch (ActiveBlock)
                    {
                        case Block.Red:
                            GameObject fr = Instantiate(fire, posi + Vector3.forward, transform.rotation);
                            
                            if (hit.collider.gameObject.name == "Green")
                            {
                                hit.collider.gameObject.SendMessage("ReadyBlock", Bonus);
                                
                            }
                            Destroy(fr, 0.5f);
                            if (hit.collider.gameObject.tag == "Wall" || hit.collider.gameObject.name == "None"
                                || hit.collider.gameObject.name == "Blue" )
                            {
                                ActiveBlock = Block.No;
                            }

                            break;
                        case Block.Blue:
                            GameObject wt = Instantiate(water, posi + Vector3.forward, transform.rotation);
                            if (hit.collider.gameObject.name == "Red")
                            {
                                hit.collider.gameObject.SendMessage("ReadyBlock", Bonus);
                                
                            }
                            Destroy(wt, 0.5f);
                            if (hit.collider.gameObject.tag == "Wall" || hit.collider.gameObject.name == "None"
                                || hit.collider.gameObject.name == "Green")
                            {
                                ActiveBlock = Block.No;
                            }

                            break;
                        case Block.Green:
                            GameObject wd = Instantiate(wind, posi + Vector3.forward, transform.rotation);
                            if (hit.collider.gameObject.name == "Blue")
                            {
                                hit.collider.gameObject.SendMessage("ReadyBlock", Bonus);
                                
                            }
                            Destroy(wd, 0.5f);
                            if (hit.collider.gameObject.tag == "Wall" || hit.collider.gameObject.name == "None"
                                || hit.collider.gameObject.name == "Red")
                            {
                                ActiveBlock = Block.No;
                            }

                            break;
                        default:
                            break;
                    }
                }
            }
        }
        /*------------------------------------------------*/

    }
}
