using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class NextTurn : MonoBehaviour
{

    public Tilemap topgrid;
    public Tilemap bottom;
    public TextMeshProUGUI Rtext;
    private float roll;
 //   private Vector3Int player1.pos = new Vector3Int(-7, -5, 0);
 //   private Vector3Int Player2.pos = new Vector3Int(-7, -5, 0);
 //   public TileBase player1.tile;
 //   public TileBase Player2.tile;
    public TileBase playerCT;
 //   private Vector3Int Player1.lastpos = new Vector3Int(-8, -5, 0);
 //   private Vector3Int Player2.lastpos = new Vector3Int(-8, -5, 0);
    private int lc = 0;
    public static float Phase = 0;
    public GameObject green;
    public GameObject pointer;
    private int minigameNum = 1;
    private int minigamePlay = 0;

    // Start is called before the first frame update
    void Start()
    {
        Rtext.text = "Press space to roll for player one!\n(red)";
       
    }



    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            roll = UnityEngine.Random.value;
            roll *= 5;
            roll += 1;
            roll = Mathf.RoundToInt(roll);
            lc = 0;
            if (Phase == 0)
            {
                Rtext.text = ("Player one moves " + roll.ToString() + " spaces!\nPress space in the green for a bonus move.");
                while (lc < roll)
                {
                    move(ref player1.pos, ref player1.lastpos);
                    
                    lc++;
                }
                Phase = 0.1f;
            }
            else if (Phase < 1)
            {
                if ((pointer.GetComponent<Transform>().position.x < (green.GetComponent<Transform>().localScale.x) / 2 + 19.3 + 2.5 && (pointer.GetComponent<Transform>().position.x) > -(green.GetComponent<Transform>().localScale.x) / 2 + 19.3 + 2.5))
                {
                    Rtext.text = ("Sucsess!\nPress space again for another bonus attempt.");
                    move(ref player1.pos, ref player1.lastpos);
                    Phase += 0.1f;
                    Slider.trianglem *= 2.5f;
                    
                    if (Phase >= 0.39f)
                    {
                        Rtext.text = ("Good job!\nPress space again to roll for player two.");
                        Phase = 1;
                        Slider.trianglem = 0.002f;
                    }
                    
                } else 
                {
                    Rtext.text = ("Failure!\nPress space again to roll for player two.");
                    Phase = 1;
                    Slider.trianglem = 0.002f;
                }
            }
            else if (Phase == 1)
            {
                Rtext.text = ("Player two moves " + roll.ToString() + " spaces!\nPress space in the green for a bonus move.");
                while (lc < roll)
                {
                    move(ref player2.pos, ref player2.lastpos);
                    
                    lc++;
                }
                Phase = 1.1f;
            }
            else if (Phase < 2)
            {
                if ((pointer.GetComponent<Transform>().position.x < (green.GetComponent<Transform>().localScale.x) / 2 + 19.3 + 2.5 && (pointer.GetComponent<Transform>().position.x) > -(green.GetComponent<Transform>().localScale.x) / 2 + 19.3 + 2.5))
                {
                    Rtext.text = ("Sucsess!\nPress space again for another bonus attempt.");
                    move(ref player2.pos, ref player2.lastpos);
                    Phase += 0.1f;
                    Slider.trianglem *= 2.5f;
                    Debug.Log(Phase);
                    if (Phase >= 1.39f)
                    {
                        Rtext.text = ("Good job!\nPress space again to commence minigames.");
                        Phase = 2;
                        Slider.trianglem = 0.002f;
                    }

                }
                else
                {
                    Rtext.text = ("Failure!\nPress space again to commence minigames.");
                    Phase = 2;
                    Slider.trianglem = 0.002f;
                }
            }
            else
            {
                minigamePlay = Mathf.FloorToInt(minigameNum * UnityEngine.Random.value + 1);
                SceneManager.LoadScene(minigamePlay);
            }

        }
        if (player1.pos == player2.pos)
        {
            topgrid.SetTile(player2.pos, playerCT);
        }
        else
        {
            topgrid.SetTile(player2.pos, player2.tile) ;
            topgrid.SetTile(player1.pos, player1.tile);
        }
  
    }

    public void move(ref Vector3Int PlayerPos, ref Vector3Int lastpos)
    {
         
        topgrid.SetTile(PlayerPos, null);

        if ((bottom.GetSprite(PlayerPos)).ToString() == "New Piskel (1) (1) (2)_7 (UnityEngine.Sprite)")
        {
            PlayerPos.x += 1;
            if (PlayerPos == lastpos)
            {
                PlayerPos.x -= 2;
                lastpos.x += -1;
            }
            else
            {
                lastpos.x += 1;
            }


        }
        else if ((bottom.GetSprite(PlayerPos)).ToString() == "New Piskel (1) (1) (2)_5 (UnityEngine.Sprite)")
        {
            PlayerPos.y += 1;
            if (PlayerPos == lastpos)
            {
                PlayerPos.y -= 2;
                lastpos.y += -1;
            }
            else
            {
                lastpos.y += 1;
            }


        }
        else if ((bottom.GetSprite(PlayerPos)).ToString() == "New Piskel (1) (1) (2)_8 (UnityEngine.Sprite)")
        {
            if (PlayerPos.x - 1 == lastpos.x)
            {
                PlayerPos.y += 1;
                lastpos.x += 1;
            }
            else
            {
                PlayerPos.x -= 1;
                lastpos.y -= 1;
            }

        }
        else if ((bottom.GetSprite(PlayerPos)).ToString() == "New Piskel (1) (1) (2)_2 (UnityEngine.Sprite)")
        {
            if (PlayerPos.y - 1 == lastpos.y)
            {
                PlayerPos.x -= 1;
                lastpos.y += 1;
            }
            else
            {
                PlayerPos.y -= 1;
                lastpos.x += 1;
            }

        }
        else if ((bottom.GetSprite(PlayerPos)).ToString() == "New Piskel (1) (1) (2)_6 (UnityEngine.Sprite)")
        {
            if (PlayerPos.x + 1 == lastpos.x)
            {
                PlayerPos.y += 1;
                lastpos.x -= 1;
            }
            else
            {
                PlayerPos.x += 1;
                lastpos.y -= 1;
            }
        }
        else if ((bottom.GetSprite(PlayerPos)).ToString() == "New Piskel (1) (1) (2)_0 (UnityEngine.Sprite)")
        {
            if (PlayerPos.y - 1 == lastpos.y)
            {
                PlayerPos.x += 1;
                lastpos.y += 1;
            }
            else
            {
                PlayerPos.y -= 1;
                lastpos.x -= 1;
            }
        }
   //   Debug.Log(((PlayerPos)).ToString() + ((lastpos)).ToString());
        
    }

    //public void minigames()
    //{
    //    if (minigamePlay == 1)
    //    {
    //        SceneManager.LoadScene(1);
    //    }
    //}
}

