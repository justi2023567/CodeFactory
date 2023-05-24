using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShow : MonoBehaviour
{
    public GameObject[] showObj;
    public GameObject[] disableObj;

    public int pressState = 0;

    public void OnPress()
    {
        if (pressState == 1)
        {
            foreach (GameObject obj in showObj)
            {
                obj.SetActive(false);
            }
            pressState = 0;
            return;
        }
        if (pressState == 0)
        {
            foreach (GameObject obj in showObj)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in disableObj)
            {
                obj.SetActive(false);
            }
            pressState = 1;
            return;
        }
    }
}
