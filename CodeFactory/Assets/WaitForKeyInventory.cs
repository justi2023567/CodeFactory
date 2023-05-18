using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitForKeyInventory : MonoBehaviour
{
    public Event keyEvent;
    public Text text;

    public PlayerController pc;

    public GameObject obj;

    public void OnClick(GameObject clicked)
    {
        obj = clicked;
    }

    public void OnGUI()
    {
        keyEvent = Event.current;

        if (keyEvent.isKey == true && obj == this.gameObject)
        {
            var keyText = keyEvent.keyCode.ToString();
            text.text = keyText;
            pc.InventoryStateKey = keyEvent.keyCode;
            obj = null;
        }
    }
}
