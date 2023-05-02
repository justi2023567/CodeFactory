using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject[] snapPC;
    public GameObject[] snapCB;

    public GameObject deleteBttn;

    public int amountInCB;
    public int amountInPC;

    public GameObject PCContent;
    public GameObject CBContent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add(GameObject button)
    {
        if (button.transform.parent.name == "Content CB")
        {
            button.transform.position = snapPC[amountInPC].transform.position;
            button.transform.parent = PCContent.transform;
            amountInPC++;
        }
    }
}
