using TMPro;
using UnityEngine;

public class InventoryUI_Button : MonoBehaviour
{
    public TMP_Text text;
    public void SetButton(ItemObject item) 
    {
        text.text = item.itemName;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
