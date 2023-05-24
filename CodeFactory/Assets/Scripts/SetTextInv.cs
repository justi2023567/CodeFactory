using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextInv : MonoBehaviour
{
    public Text text;

    public bool ifstone;
    public bool ifcoal;
    public bool ifiron;
    public bool ifgold;
    public bool ifdiamond;

    public Inventory playerInventory;

    // Update is called once per frame
    void Update()
    {
        if (ifstone == true)
        {
            text.text = "Stone: " + playerInventory.stoneCount.ToString();
        }
        if (ifcoal == true)
        {
            text.text = "Coal: " + playerInventory.coalCount.ToString();
        }
        if (ifiron == true)
        {
            text.text = "Iron: " + playerInventory.ironCount.ToString();
        }
        if (ifgold == true)
        {
            text.text = "Gold: " + playerInventory.goldCount.ToString();
        }
        if (ifdiamond == true)
        {
            text.text = "Diamond: " + playerInventory.diamondCount.ToString();
        }
    }
}
