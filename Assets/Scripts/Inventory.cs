using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<string> items = new List<string>();

    private string[] random_loot = { "Gold", "Silver", "Diamond", "Sword", "Axe" };


    public GameManagerCLASS gameManager;
    private void AddToInventory(string name)
    {
        Debug.Log("Added item");
        items.Add(name);
    }
    private void RemoveFromInventory(string name)
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
        OnControllerColliderHit hit = null;
        ItemObject collisionItem = hit.gameObject.GetComponent<ItemObject>();

        gameManager = FindAnyObjectByType<GameManagerCLASS>();
        bool isPlaying = gameManager.isPlaying;

        if (isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                int rnd = Random.Range(0, random_loot.Length);
                AddToInventory(random_loot[rnd]);
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("Removed item");
                RemoveFromInventory(items[0]);
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("Sorted list");
                items.Sort();
            }
        }
    }
}

