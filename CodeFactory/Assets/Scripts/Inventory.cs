using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // A keycode you can edit on Unity under this script
    public KeyCode addOresButton;

    // Variables to count collected Ores
    public int stoneCount = 0;
    public int coalCount = 0;
    public int ironCount = 0;
    public int goldCount = 0;
    public int diamondCount = 0;

    // Variables to count Pogs (in-game currency)
    public int pogCount = 0;
    public int bronzePogCount = 0; // Same as 10 Pogs
    public int silverPogCount = 0; // Same as 10 Bronze Pogs
    public int goldPogCount = 0; // Same as 10 Silver Pogs
    public int diamondPogCount = 0; // Same as 10 Gold Pogs

    public void FixedUpdate()
    {
        // Gives 1 of every ore to test the selling system (DEV ONLY)
        if (Input.GetKeyDown(addOresButton))
        {
            stoneCount++;
            coalCount++;
            ironCount++;
            goldCount++;
            diamondCount++;
        }
    }
}
