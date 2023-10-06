using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("# Panel")]

    public GameObject inventoryPanel;
    bool inventoryActive = false;
    public GameObject statsPanel;
    bool statsActive = false;
    public GameObject shopPanel;
    bool shopActive = false;

    private void Start()
    {
        inventoryPanel.SetActive(inventoryActive);
        statsPanel.SetActive(statsActive);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            inventoryActive = !inventoryActive;
            inventoryPanel.SetActive(inventoryActive);
        }

        if (Input.GetKeyUp(KeyCode.O))
        {
            statsActive = !statsActive;
            statsPanel.SetActive(statsActive);
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            shopActive = !shopActive;
            shopPanel.SetActive(shopActive);
        }
    }
}
