using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class inventoryUI : MonoBehaviour
{
    // Holds the inventory's UI gameobject
    public GameObject inventory;

    // Holds the inventory UI icon
    public GameObject inventoryIcon;

    // Holds the inventory on and off icons
    public Sprite inventoryIconOn;
    public Sprite inventoryIconOff;

    // Holds all the text gameobjects
    public GameObject stoneText;
    public GameObject coalText;
    public GameObject ironText;
    public GameObject goldText;
    public GameObject diamondText;
    public GameObject pogText;
    public GameObject bronzePogText;
    public GameObject silverPogText;
    public GameObject goldPogText;
    public GameObject diamondPogText;
    public GameObject botsAcquiredText;

    // Creates a keycode for the interact button
    public KeyCode InteractButton;

    // Used to refrence the players inventory
    public Inventory script;

    //Create a scirpt variable for Player's controller
    public PlayerController pc;

    // Used to check if the inventory is open
    public bool open = false;

    // Update is called once per frame
    void Update()
    {
        // Code used to find the amount of abjects with the tag 'Bot'
        var botsAmount = GameObject.FindGameObjectsWithTag("Bot").Length;

        // Changes all the text of the inventory dynamically according to the item
        stoneText.GetComponent<TextMeshProUGUI>().text = "Stone: " + script.stoneCount;
        coalText.GetComponent<TextMeshProUGUI>().text = "Coal: " + script.coalCount;
        ironText.GetComponent<TextMeshProUGUI>().text = "Iron: " + script.ironCount;
        goldText.GetComponent<TextMeshProUGUI>().text = "Gold: " + script.goldCount;
        diamondText.GetComponent<TextMeshProUGUI>().text = "Diamond: " + script.diamondCount;
        pogText.GetComponent<TextMeshProUGUI>().text = "Pogs: " + script.pogCount;
        bronzePogText.GetComponent<TextMeshProUGUI>().text = "Bronze Pogs: " + script.bronzePogCount;
        silverPogText.GetComponent<TextMeshProUGUI>().text = "Silver Pogs: " + script.silverPogCount;
        goldPogText.GetComponent<TextMeshProUGUI>().text = "Gold Pogs: " + script.goldPogCount;
        diamondPogText.GetComponent<TextMeshProUGUI>().text = "Diamond Pogs: " + script.diamondPogCount;
        botsAcquiredText.GetComponent<TextMeshProUGUI>().text = "Bots: " + botsAmount;

        // If the interact button is pressed and the inventory is not open
        if (Input.GetKeyDown(InteractButton) && open == false && pc.playing == true && pc.open == false)
        {
            // Turns the inventory icon to its on state
            inventoryIcon.GetComponent<Image>().sprite = inventoryIconOn;
            // Sets pc.playing to false
            pc.playing = false;
            // Activate the inventory
            inventory.SetActive(true);
            // Set open to true
            open = true;
            return;
        }
        // If the interact button is pressed and the inventory is open
        if (Input.GetKeyDown(InteractButton) && open == true && pc.playing == false)
        {
            // Sets pc.playing to true
            pc.playing = true;
            // Deactivate the inventory
            inventory.SetActive(false);
            // Set open to false
            open = false;
            return;
        }
        // If the inventory is not open
        if (open == false)
        {
            // Turns the inventory icon to its off state
            inventoryIcon.GetComponent<Image>().sprite = inventoryIconOff;
        }
    }
}
