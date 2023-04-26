using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreMining : MonoBehaviour
{
    public GameObject ore;
    public string oreGot;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Ore Test");
    }

    // Update is called once per frame
    void Update()
    {
        // Destroys ore and tells you what you got (testing purposes only)
        if (Input.GetKey(KeyCode.Alpha1) && GetComponent<BoxCollider>())
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            var playerInv = Player.GetComponent<Inventory>();

            // Ore Randomization
            var ranNum = Random.Range(0, 100) + 1;
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
            Destroy(this.GetComponent<BoxCollider>());
            this.GetComponent<MeshRenderer>().enabled = false;
            Debug.Log("Ore Destroyed");
            Debug.Log(oreGot);
        }
        // Makes a new ore (testing purposes only)
        if (Input.GetKey(KeyCode.Alpha2) && !GetComponent<BoxCollider>())
        {
            Instantiate(ore);
            ore.GetComponent<MeshRenderer>().enabled = true;
            Debug.Log("Ore Created");
        }
    }
}
