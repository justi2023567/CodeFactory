﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
This code was made by Logan from code factory. This code is used for
make the ore random each and everytime, while giving out the correct
ore to the player.
*/
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
    public GameObject StoneD;
    public GameObject IronD;
    public GameObject CoalD;
    public GameObject GoldD;
    public GameObject DiamondD;

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
        Player = GameObject.FindGameObjectWithTag("Player");
        var playerInv = Player.GetComponent<Inventory>();

        if (oreClosest.GetComponent<OreHealth>().health <= 0)
        {
            // Ore Randomization Start
            // This entire section makes it so that when the ore's hp is zero, it takes the random number that we just had made, and use it to give the player the ore that they just made the robots mine.
            if (ranNum <= 50)
            {
                playerInv.stoneCount += 1;
                var StoneOreReplacement = Instantiate(StoneD, oreClosest.gameObject.transform.position, Quaternion.identity);
                // Vector3 StonePos = oreClosest.gameObject.transform.position;
            }
            if (ranNum > 50 && ranNum <= 73)
            {
                playerInv.coalCount += 1;
                var CoalOreReplacement = Instantiate(CoalD, oreClosest.gameObject.transform.position, Quaternion.identity);
                // Vector3 CoalPos = oreClosest.gameObject.transform.position;
            }
            if (ranNum > 73 && ranNum <= 91)
            {
                playerInv.ironCount += 1;
                var IronOreReplacement = Instantiate(IronD, oreClosest.gameObject.transform.position, Quaternion.identity);
                // Vector3 IronPos = oreClosest.gameObject.transform.position;
            }
            if (ranNum > 91 && ranNum < 100)
            {
                playerInv.goldCount += 1;
                var GoldOreReplacement = Instantiate(GoldD, oreClosest.gameObject.transform.position, Quaternion.identity);
                // Vector3 GoldPos = oreClosest.gameObject.transform.position;
            }
            if (ranNum == 100)
            {
                playerInv.diamondCount += 1;
                var DiamondOreReplacement = Instantiate(DiamondD, oreClosest.gameObject.transform.position, Quaternion.identity);
                // Vector3 DiamondPos = oreClosest.gameObject.transform.position;
            }
        }
    }
}