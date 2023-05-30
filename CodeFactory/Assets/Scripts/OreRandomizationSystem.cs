using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreRandomizationSystem : MonoBehaviour
{
    // Holds the ore that will randomly spawn
    public GameObject randomOrePrefab;

    // Holds the range of coordinates where the ores can spawn
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;


    // Start is called before the first frame update
    void Start()
    {
        // Calls the randomOre() function
        StartCoroutine(randomOre());
    }

    //Starts a function
    public IEnumerator randomOre()
    {
        while (true)
        {
            // Tells the code to wait a bit when the function is called
            yield return new WaitForSeconds(.05f);

            // Randomizes the coordinates where the ores will spawn
            var randX = Random.Range(minX, maxX);
            var randZ = Random.Range(minZ, maxZ);

            // Makes the ore at said coordinates
            Instantiate(randomOrePrefab, new Vector3(randX, 50f, randZ), Quaternion.identity);
        }
    }
}
