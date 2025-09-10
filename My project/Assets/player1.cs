using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;
public class player1 : MonoBehaviour
{
    public TileBase tilesetter;
    public static TileBase tile;
    public static Vector3Int lastpos = new Vector3Int(-8, -5, 0);
    public static Vector3Int pos = new Vector3Int(-7, -5, 0);
    public static int points = 0;
    void Awake()
    {
        tile = tilesetter;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
