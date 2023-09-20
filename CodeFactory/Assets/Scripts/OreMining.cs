using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreMining : MonoBehaviour
{
    // These variables hold assets
    public GameObject[] ore;
    public GameObject orePrefab;
    public GameObject oreExplode;
    public GameObject sparkPrefab;
    public GameObject oreClosest;

    // Variable to tell if the ore has blown up or not
    public bool blowup = false;
    public bool ore_detection = false;
    // Variables to tell if the ore has been collected
    public bool collectOre = false;

    // Variables to control the power and radius of the explosion
    public float radius = 5f;
    public float power = 175f;

    // The Player object
    public GameObject Player;

    // Controls the time between being able to break a block (needs to be changed in Unity also)
    public float firerate = 1f;
    public float nextfire = 1f;

    // Holds particles
    public ParticleSystem sparks;

    // Update is called once per frame


     void FixedUpdate()
    {


        // Destroys ore when orebot mines ore
        // Debug.Log(blowup);
        // Debug.Log(oreClosest);
        if (blowup == true && oreClosest != null)
        {
            // Gets Player tag to add ores to inventory
            Player = GameObject.FindGameObjectWithTag("Player");

            // Gets the Player's inventory by using the Player tag and assigns it as a variable
            var playerInv = Player.GetComponent<Inventory>();

            // Ore Randomization Start
            // Makes a number from 1 to 100
            if (oreClosest.GetComponent<OreHealth>().health <= 0)
            {
                var ranNum = Random.Range(0, 100) + 1;

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
                // Ore Randomization End


                // Replaces the destroyed ore with an ore exploding animation. Starts Here.
                var cloneOreExplode = Instantiate(oreExplode, oreClosest.gameObject.transform.position, Quaternion.identity); // Clones the oreExplode asset so I can delete the cloned asset instead of the original asset
                Vector3 explosionPos = oreClosest.gameObject.transform.position; // Sets the coordinates of the explosion
                Collider[] colliders = Physics.OverlapSphere(explosionPos, radius); //Finds every collider in a radius
                                                                                    // Loops through all the colliders
                                                                                    // Destroys the ore
                Destroy(oreClosest.gameObject);
                foreach (Collider hit in colliders)
                {
                    // Gets the colliders rigidbody
                    Rigidbody rb = hit.GetComponent<Rigidbody>();

                    // If the collider has a rigidbody, the explosion occurs
                    if (rb != null && hit.gameObject.tag == "StoneChunk")
                        rb.AddExplosionForce(power, explosionPos, radius, 1.0F); // 'power' controls the power of the explosion, 'explosionPos' sets the coordinates of the explosion, 'radius' controls the radius of the explosion, and the number controls the height of the explosion.
                }
                blowup = false; // Sets the blowup variable to false so the next ore can blowup
                Destroy(cloneOreExplode, 9.25f); // Destroys the cloned ore asset after 9.25 seconds
                                                 // Replaces the destroyed ore with an ore exploding animation. Ends here.
            }
            else if (Time.time > nextfire)
            {
                // Controls the time before the next mining process
                nextfire = Time.time + firerate;
                var pref = Instantiate(sparkPrefab, new Vector3(oreClosest.gameObject.transform.position.x, oreClosest.gameObject.transform.position.y + .7f, oreClosest.gameObject.transform.position.z), Quaternion.identity);
                Destroy(pref, 2f);
                oreClosest.GetComponent<OreHealth>().health--;
            }
        }

    }

}

