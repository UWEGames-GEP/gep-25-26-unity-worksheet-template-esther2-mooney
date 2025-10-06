using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<string> items = new List<string>();

    public GameManagerCLASS gameManager;
    public void AddToInventory(string name)
    {
        items.Add(name);
    }
    public void RemoveFromInventory(string name)
    {
        items.Remove(name);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        gameManager = FindAnyObjectByType<GameManagerCLASS>();
        bool isPlaying = gameManager.isPlaying;

        if (isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("Added item");
                AddToInventory("GenericItem");

            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("Removed item");
                RemoveFromInventory("GenericItem");

            }
        }
    }
}

