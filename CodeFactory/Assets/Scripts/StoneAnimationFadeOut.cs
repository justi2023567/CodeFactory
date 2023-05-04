using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneAnimationFadeOut : MonoBehaviour
{
    public float alpha = 1f;
    public Color objectColor;
    public float fadeTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        objectColor = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("fadeOut", 5);
    }

    void fadeOut()
    {
        alpha -= Time.deltaTime / fadeTime;
        alpha = Mathf.Clamp01(alpha); // clamp alpha value between 0 and 1
        objectColor.a = alpha;
        GetComponent<Renderer>().material.color = objectColor;
    }
}
