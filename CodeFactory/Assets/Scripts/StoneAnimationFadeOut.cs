using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneAnimationFadeOut : MonoBehaviour
{
    public float alpha = 1f; // Variable for the alpha value
    public Color objectColor; // Variable for the objects color

    // Start is called before the first frame update
    void Start()
    {
        objectColor = GetComponent<Renderer>().material.color; // Gets object color
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("fadeOut", 5); // Function fadeOut() is called after 5 seconds
    }

    void fadeOut()
    {
        alpha -= Time.deltaTime / fadeTime; // Lessens the alpha value
        alpha = Mathf.Clamp01(alpha); // Makes sure theirs no negative alpha values
        objectColor.a = alpha; // Apply that alpha to the objects alpha
        GetComponent<Renderer>().material.color = objectColor; // Render that new color
    }
}
