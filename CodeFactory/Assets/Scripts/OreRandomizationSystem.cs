using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreRandomizationSystem : MonoBehaviour
{
    public GameObject randomOrePrefab;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(randomOre());
    }

    public IEnumerator randomOre()
    {
        while (true)
        {
            yield return new WaitForSeconds(.3f);

            var randX = Random.Range(minX, maxX);
            var randZ = Random.Range(minZ, maxZ);

            Instantiate(randomOrePrefab, new Vector3(randX, 50f, randZ), Quaternion.identity);
        }
    }
}
