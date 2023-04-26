using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitForKey : MonoBehaviour
{
    public Event keyEvent;
    public Text text;

    public PlayerController pc;

    private void OnGUI()
    {
        keyEvent = Event.current;

        if (keyEvent.isKey == true)
        {
            var keyText = keyEvent.keyCode.ToString();
            text.text = keyText;
            pc.CameraStateKey = keyEvent.keyCode;
        }
    }
}
