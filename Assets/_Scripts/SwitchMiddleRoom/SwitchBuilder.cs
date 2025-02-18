using UnityEngine;
using TMPro;

public class SwitchBuilder : MonoBehaviour
{
    public GameObject switchOutline;
    public GameObject realSwitch;
    public TextMeshProUGUI collectedPartsText;
    public LayerMask whatIsPlayer;
    public TextMeshProUGUI interactionText;
    private bool switchBuilt = false;

    private void Start()
    {
        realSwitch.SetActive(false);
        interactionText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // This if statement is using bitwise operators to check a gameobject's layer compared to the wanted layer (WhatIsPlayer)
        // Show text when entering the collider of the middle switch object
        if ((whatIsPlayer.value & (1 << other.gameObject.layer)) > 0)
        {
            if (collectedPartsText.text == "You have collected 3/3 switch-parts")
            {
                interactionText.text = "Press \"E\" to build switch";
            }
            else
            {
                interactionText.text = "You don't have the required parts";
            }
            interactionText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // This if statement is using bitwise operators to check a gameobject's layer compared to the wanted layer (WhatIsPlayer)
        if ((whatIsPlayer.value & (1 << other.gameObject.layer)) > 0)
        {
            // Hides the text
            interactionText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        //Check if you can build the switch
        if (collectedPartsText.text == "You have collected 3/3 switch-parts" && Input.GetKeyDown(KeyCode.E) && switchOutline.activeSelf && !switchBuilt)
        {
            BuildSwitch();
            collectedPartsText.gameObject.SetActive(false);
            
        }

        if (switchBuilt && interactionText.gameObject.activeSelf)
        {
            interactionText.gameObject.SetActive(false);
        }
    }
    //Build switch
    private void BuildSwitch()
    {
        switchOutline.SetActive(false);
        realSwitch.SetActive(true);
        switchBuilt = true;
    }
}
