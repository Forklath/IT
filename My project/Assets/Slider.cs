using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Slider : MonoBehaviour
{
    public GameObject whole;
    public static float trianglem = 0.002f;
    public GameObject pointer;

    // Start is called before the first frame update
    void Start()
    {
        whole.GetComponent<Transform>().position += new Vector3Int(0, 0, 100);
    }

    // Update is called once per frame
    void Update()
    {
        (pointer.GetComponent<Transform>().position) += new Vector3(trianglem,0,0);
        if (pointer.GetComponent<Transform>().position.x > 2.1+19.3+2.5 || pointer.GetComponent<Transform>().position.x < -2.1+19.3+2.5)
        {
            //Debug.Log(pointer.GetComponent<Transform>().position);
            trianglem *= -1;
        }

        if ((NextTurn.Phase > 0 && NextTurn.Phase < 1) || (NextTurn.Phase >1 && NextTurn.Phase < 2))
        {
         // Debug.Log("Phase 0.1");
            whole.GetComponent<Transform>().position = new Vector3(19.3f, 15.4f, 10f);
        }
        else
        {
            whole.GetComponent<Transform>().position += new Vector3Int(0, 0, 100);
        }

    }
}
