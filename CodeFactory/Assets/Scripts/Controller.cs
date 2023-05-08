using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject[] snapPC;
    public GameObject[] snapCB;

    public GameObject[] programChip;
    public GameObject[] codeBlocks;

    public GameObject deleteBttn;

    public GameObject PCContent;
    public GameObject CBContent;

    public void Add(GameObject button)
    {
        if (button.transform.parent.name == "Content CB")
        {
            foreach (GameObject snap in snapCB)
            {
                if (Vector3.Distance(button.transform.position, snap.transform.position) <= .1f)
                {
                    snap.GetComponent<SnapUse>().used = false;
                }
            }
            foreach (GameObject snap in snapPC)
            {
                if (snap.GetComponent<SnapUse>().used == false)
                {
                    button.transform.position = snap.transform.position;
                    button.transform.parent = PCContent.transform;
                    snap.GetComponent<SnapUse>().used = true;
                    return;
                }
            }
        }
        if (button.transform.parent.name == "Content PC")
        {
            foreach(GameObject snap in snapPC)
            {
                if (Vector3.Distance(button.transform.position, snap.transform.position) <= .1f)
                {
                    snap.GetComponent<SnapUse>().used = false;
                }
            }
            foreach (GameObject snap in snapCB)
            {
                if (snap.GetComponent<SnapUse>().used == false)
                {
                    button.transform.position = snap.transform.position;
                    button.transform.parent = CBContent.transform;
                    snap.GetComponent<SnapUse>().used = true;
                    return;
                }
            }
        }
    }
}
