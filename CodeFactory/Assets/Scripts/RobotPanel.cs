using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RobotPanel : MonoBehaviour
{
    //This script controls how the robot programming menu is opened and closed

    //Creates a gameobject variable for a canvas
    public GameObject canvas;
    //Creates a gameobject variable for the console
    public GameObject console;

    //When the void script is called
    public void Script()
    {
        //Deactivate the canvas
        canvas.SetActive(false);
        //Activate the console
        console.SetActive(true);
    }

    //When the void exit is called
    public void Exit()
    {
        //Activate the canvas
        canvas.SetActive(false);
    }

    //When the void back is called
    public void Back()
    {
        //Deactivate the console
        console.SetActive(false);
        //Activate the canvas
        canvas.SetActive(true);
    }

    //When the onmousedown is called
    private void OnMouseDown()
    {
        //Activate the canvas
        canvas.SetActive(true);
    }
}

