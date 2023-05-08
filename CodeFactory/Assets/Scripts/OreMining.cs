using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreMining : MonoBehaviour
{
    // These variables hold assets
    public GameObject ore;
    public GameObject orePrefab;
    public GameObject oreExplode;

    // Variable to tell if the ore has blown up or not
    public bool blowup = false;

    // Variables to tell if the ore has been collected
    public bool collectOre = false;
    public string oreGot;

    // Variables to control the power and radius of the explosion
    public float radius = 3f;
    public float power = 200f;

    // The Player object
    public GameObject Player;

    // Controls the time between a new block being made (needs to be changed in Unity also)
    public float firerate = 1f;
    public float nextfire = 4f;

    // Start is called before the first frame update
    void Start()
    {

    }

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

            // Replaces the destroyed ore with an ore exploding animation. Starts Here.
            var cloneOreExplode = Instantiate(oreExplode, new Vector3(1.13f, 0.8336654f, 7.76f), Quaternion.identity); // Clones the oreExplode asset so I can delete the cloned asset instead of the original asset
            Vector3 explosionPos = new Vector3(1.13f, 0.8336654f, 7.76f); // Sets the coordinates of the explosion
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius); //Finds every collider in a radius
            // Loops through all the colliders
            foreach (Collider hit in colliders)
            {
                // Gets the colliders rigidbody
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                // If the collider has a rigidbody, the explosion occurs
                if (rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius, 1.0F); // 'power' controls the power of the explosion, 'explosionPos' sets the coordinates of the explosion, 'radius' controls the radius of the explosion, and the number controls the height of the explosion.
            }
            blowup = false; // Sets the blowup variable to false so the next ore can blowup
            Destroy(cloneOreExplode, 9.25f); // Destroys the cloned ore asset after 9.25 seconds
            // Replaces the destroyed ore with an ore exploding animation. Ends here.
        }
        // Makes a new ore when 2 is pressed (testing purposes only)
        // Will be changed to ores respawning overtime with random generation in a set area
        if (Input.GetKey(KeyCode.Alpha2) && Time.time > nextfire)
        {
            // Controls the time before the next ore can be made
            nextfire = Time.time + firerate;

            // New ore is made at selected coordinates
            Instantiate(orePrefab, new Vector3(1.13f, 0.8336654f, 7.76f), Quaternion.identity);
            Debug.Log("Ore Created");
        }
    }
}
