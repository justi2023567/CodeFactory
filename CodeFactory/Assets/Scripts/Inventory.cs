using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Variables to count collected ores
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
        // Displays your ore count when 3 is pressed (testing purposes only)
        // Will be changed to an official key to view your entire inventory
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Debug.Log("Stone:" + stoneCount);
            Debug.Log("Coal:" + coalCount);
            Debug.Log("Iron:" + ironCount);
            Debug.Log("Gold:" + goldCount);
            Debug.Log("Diamond:" + diamondCount);
        }
    }
}
