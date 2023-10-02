﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreRandom : MonoBehaviour
{
    // public script OreMining;
    public GameObject Ore;
    public GameObject oreClosest;
    public GameObject Player;
    public Material stoneMaterial;
    public Material coalMaterial;
    public Material ironMaterial;
    public Material goldMaterial;
    public Material diamondMaterial;

    public int ranNum;
    // Start is called before the first frame update
    public void Start()
    {
        ranNum = Random.Range(0, 100) + 1;
        // Uses the randomly selected number to chose an ore and add it to the player's inventory
        if (ranNum <= 50)
        {
            // Stone
            Ore.GetComponent<Renderer>().material = stoneMaterial;
        }
        if (ranNum > 50 && ranNum <= 73)
        {
            // Coal
            Ore.GetComponent<Renderer>().material = coalMaterial;
        }
        if (ranNum > 73 && ranNum <= 91)
        {
            // Iron
            Ore.GetComponent<Renderer>().material = ironMaterial;
        }
        if (ranNum > 91 && ranNum < 100)
        {
            // Gold
            Ore.GetComponent<Renderer>().material = goldMaterial;
        }
        if (ranNum == 100)
        {
            // Diamond
            Ore.GetComponent<Renderer>().material = diamondMaterial;
        }
    }

    void FixedUpdate()
    {
        
        /*
        //oreClosest = GetComponent<OreMining>().oreClosest;
        Player = GameObject.FindGameObjectWithTag("Player");
        var playerInv = Player.GetComponent<Inventory>();

        if (oreClosest.GetComponent<OreHealth>().health <= 0)
        {
            var ranNum = Random.Range(0, 100) + 1;
            // Ore Randomization Start
            // Uses the randomly selected number to chose an ore and add it to the player's inventory
            if (ranNum <= 50)
            {
                playerInv.stoneCount += 1;
            }
            if (ranNum > 50 && ranNum <= 73)
            {
                playerInv.coalCount += 1;
            }
            if (ranNum > 73 && ranNum <= 91)
            {
                playerInv.ironCount += 1;
            }
            if (ranNum > 91 && ranNum < 100)
            {
                playerInv.goldCount += 1;
            }
            if (ranNum == 100)
            {
                playerInv.diamondCount += 1;
            }
        }
        */
    }
}