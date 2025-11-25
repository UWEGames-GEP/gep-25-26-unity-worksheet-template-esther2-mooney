using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    private List<GameObject> ui_buttons = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnEnable()
    {
        RefreshInventory();
    }
    
    void RefreshInventory()
    {
       // Debug.Log("Refresh Inventory UI");
        foreach (GameObject button in ui_buttons) 
        {
           //Debug.Log("setinactive");
            button.SetActive(false);       
        }

        for (int i =0; i <inventory.items.Count; i++)
        {
            if (i < ui_buttons.Count)
            {
                InventoryUI_Button button = ui_buttons[i].GetComponent<InventoryUI_Button>();
                ItemObject item = inventory.items[i];   
                button.gameObject.SetActive(true);
                button.SetButton(item);
                        }
        }
    }

    public void OnInventoryUIButton(int i)
    {
        inventory.RemoveItem(i);
        RefreshInventory();
    }
    void Start()
    {
        InventoryUI_Button[] allButtons = GetComponentsInChildren<InventoryUI_Button>();
        foreach (InventoryUI_Button button in allButtons)
        {
            button.gameObject.SetActive(false);
            ui_buttons.Add(button.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
