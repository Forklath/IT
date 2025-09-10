using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class RopePull : MonoBehaviour
{
    public TextMeshProUGUI MainText;
    public TextMeshProUGUI countdown;
    private int dispcount = 3;
    private int Phase1 = 0;
    private int ogt = 0;
    public GameObject rope;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Phase1);
        //Debug.Log(DateTime.Now.Second);
        if (Input.GetKeyDown(KeyCode.Space) && Phase1 == 0)
        {
            MainText.text = "Starting in:";
            countdown.text = Mathf.RoundToInt(dispcount).ToString();
            Phase1 = 1; 
            ogt = DateTime.Now.Second;
        }
        else if (Phase1 == 0)
        {
         //   Debug.Log((DateTimeOffset.Now.ToUnixTimeMilliseconds()));
          //  Debug.Log((Mathf.Sin(DateTimeOffset.Now.ToUnixTimeMilliseconds()/1000* Mathf.Deg2Rad)));
          //  MainText.GetComponent<Transform>().localScale += (new Vector3(Mathf.Sin(DateTimeOffset.Now.ToUnixTimeMilliseconds() /1000), Mathf.Sin(DateTimeOffset.Now.ToUnixTimeMilliseconds() /1000), Mathf.Sin(DateTimeOffset.Now.ToUnixTimeMilliseconds())))/2000;
        }
        else if (Phase1 == 1) 
        {
            countdown.text = Mathf.RoundToInt(dispcount).ToString();
            if ((ogt != DateTime.Now.Second))
            {
                dispcount -= 1;
                ogt = DateTime.Now.Second;
            }
            if (dispcount < 0)
            {
                Phase1 = 2;
                countdown.text = null;
                MainText.text = "GO";
            }
        }
        else if (Phase1 == 2)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                rope.GetComponent<Transform>().position += new Vector3(0.6f,0,0);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                rope.GetComponent<Transform>().position -= new Vector3(0.6f,0,0); //I know I dont need the f but its for when I tweak the speed with decimals ok I do actually need it now so it was fine
            }
            if (rope.GetComponent<Transform>().position.x >= 3.75f) 
            {
                MainText.text = "PLAYER TWO WINS!!";
                player2.points += 1;
                ogt = DateTime.Now.Second;
                Phase1 = 3;
            }
            if(rope.GetComponent<Transform>().position.x <= -3.75f)
            {
                MainText.text = "PLAYER ONE WINS!!";
                player1.points += 1;
                ogt = DateTime.Now.Second;
                Phase1 = 3;
            }
        }
        else if (Phase1 == 3)
        {
            if (ogt+2 == DateTime.Now.Second||(ogt>DateTime.Now.Second&& DateTime.Now.Second>1))
            {
                NextTurn.Phase = 0;
                SceneManager.LoadScene(0);
            }
        }

    }
}
