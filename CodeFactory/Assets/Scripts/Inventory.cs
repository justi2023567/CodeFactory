using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int stoneCount = 0;
    public int coalCount = 0;
    public int ironCount = 0;
    public int goldCount = 0;
    public int diamondCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Debug.Log(stoneCount);
            Debug.Log(coalCount);
            Debug.Log(ironCount);
            Debug.Log(goldCount);
            Debug.Log(diamondCount);
        }
    }
}
