using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GodMode : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private bool godModeEnabled = false;
    public PlayerHealth playerHealth;
    public TextMeshProUGUI guideLine;
    public TextMeshProUGUI switchParts;
    public TextMeshProUGUI disableActiveMonster;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }
    //press key to enable godmode
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            godModeEnabled = !godModeEnabled;
            UpdateText();
        }
    }
     
    private void UpdateText()
    {   
        if (godModeEnabled)
        {
            // change collor of text, show guildlines, increas healt.
            playerHealth.currentHealth = 10000;
            guideLine.gameObject.SetActive(true);
            switchParts.gameObject.SetActive(true);
            disableActiveMonster.gameObject.SetActive(true);
            textMeshPro.text = "Press 1 - God Mode: Enabled";
            textMeshPro.color = new Color32(0, 128, 0, 255); // Dark green
        }
        else
        {
            // change collor back,hide guildlines, reduce healt 
            playerHealth.currentHealth = 100;
            guideLine.gameObject.SetActive(false);
            switchParts.gameObject.SetActive(false);
            disableActiveMonster.gameObject.SetActive(false);
            textMeshPro.text = "Press 1 - God Mode: Disabled";
            textMeshPro.color = new Color32(253, 182, 0, 255); // FDB600
        }
    }
}
