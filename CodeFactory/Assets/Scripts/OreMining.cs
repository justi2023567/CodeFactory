using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreMining : MonoBehaviour
{
    public GameObject ore;
    public GameObject orePrefab;
    public GameObject oreExplode;

    public bool blowup = false;

    public string oreGot;

    public GameObject Player;

    // Controls the time between a new block being made (needs to be changed in Unity also)
    public float firerate = 1f;
    public float nextfire = 4f;

    // Update is called once per frame
    void Update()
    {
        // Destroys ore when orebot mines ore
        if (blowup == true)
        {
            // Gets Player tag to add ores to inventory
            Player = GameObject.FindGameObjectWithTag("Player");

            // Gets the Player's inventory by using the Player tag and assigns it as a variable
            var playerInv = Player.GetComponent<Inventory>();

            // Gets ore tag to delete all items with the ore tag
            ore = GameObject.FindGameObjectWithTag("ore");

            // Ore Randomization Start
            // Makes a number from 1 to 100
            var ranNum = Random.Range(0, 100) + 1;

            // Uses the randomly selected number to chose an ore and add it to the player's inventory
            if (ranNum <= 50)
            {
                oreGot = "Stone";
                playerInv.stoneCount += 1;
            }
            if (ranNum > 50 && ranNum <= 73)
            {
                oreGot = "Coal";
                playerInv.coalCount += 1;
            }
            if (ranNum > 73 && ranNum <= 91)
            {
                oreGot = "Iron";
                playerInv.ironCount += 1;
            }
            if (ranNum > 91 && ranNum < 100)
            {
                oreGot = "Gold";
                playerInv.goldCount += 1;
            }
            if (ranNum == 100)
            {
                oreGot = "Diamond";
                playerInv.diamondCount += 1;
            }
            // Ore Randomization End

            // Destroys the ore
            Destroy(ore.gameObject);
            Debug.Log("Ore Destroyed");
            Debug.Log(oreGot);

            // Replaces the destroyed ore with an ore exploding animation
            Instantiate(oreExplode);
            blowup = false;
        }
        // Makes a new ore when 2 is pressed (testing purposes only)
        // Will be changed to ores respawning overtime with random generation in a set area
        if (Input.GetKey(KeyCode.Alpha2) && Time.time > nextfire)
        {
            nextfire = Time.time + firerate;

            // New ore is made at selected coordinates
            Instantiate(orePrefab, new Vector3(1.13f, 0.8336654f, 7.76f), Quaternion.identity);
            Debug.Log("Ore Created");
        }
    }
}
