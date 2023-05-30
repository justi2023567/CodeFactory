using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingController : MonoBehaviour
{
    public GameObject[] oresTotal;
    public GameObject Spawner;
    public GameObject Backscreen;
    public GameObject LoadingText;
    public GameObject LockText;
    public GameObject player;

    public float firerate = 7f;
    public float nextfire = 1f;

    // Update is called once per frame
    void Update()
    {
        oresTotal = GameObject.FindGameObjectsWithTag("ore");

        if (oresTotal.Length >= 150)
        {
            if (Time.time > nextfire)
            {
                nextfire = Time.time + firerate;
                StartCoroutine(LimitReached());
            }
        }
        else
        {
            player.GetComponent<PlayerController>().playing = false;
        }
    }

    public IEnumerator LimitReached()
    {
        Spawner.SetActive(false);
        yield return new WaitForSeconds(12f);
        Backscreen.SetActive(false);
        LoadingText.SetActive(false);
        LockText.SetActive(true);
        player.GetComponent<PlayerController>().playing = true;
        StopAllCoroutines();
        Destroy(this);
    }
}
