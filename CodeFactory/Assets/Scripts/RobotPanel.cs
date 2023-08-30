using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RobotPanel : MonoBehaviour
{
    // needs comments
    public GameObject canvas;
    public GameObject console;
    public void Script()
    {
        canvas.SetActive(false);
        console.SetActive(true);
    }

    public void Exit()
    {
        canvas.SetActive(false);
    }

    public void Back()
    {
        console.SetActive(false);
        canvas.SetActive(true);
    }

    private void OnMouseDown()
    {
        canvas.SetActive(true);
    }

}

