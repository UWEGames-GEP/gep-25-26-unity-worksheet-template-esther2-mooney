using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<string> items = new List<string>();
    private string[] random_loot = { "Gold", "Silver", "Diamond", "Sword", "Axe", "GUn.", "Bow", "the evil." };

    public GameManagerCLASS gameManager;
    public ItemObject hit;
    public AudioSource source;
    public AudioClip clip;
    private void AddToInventory(string name)
    {
        //add to list
        if (name.Contains("Gold Chest"))
        {
            while (true)
            {
                int rnd = Random.Range(0, random_loot.Length);
                if (random_loot[rnd] != "")
                {
                    items.Add(random_loot[rnd]);
                    random_loot[rnd] = "";
                    break;
                }
            }
        }
        else
        {
            items.Add(name);
        } 
    }
    private void RemoveFromInventory(string name)
    {
        items.Remove(name);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {}

    // Update is called once per frame
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        ItemObject collisionItem = hit.gameObject.GetComponent<ItemObject>();
        if (collisionItem != null)  
        {
            AddToInventory(collisionItem.name);
            source.PlayOneShot(clip);
            Destroy(collisionItem.gameObject);
        }
    }
    private void Update()
    {        
        gameManager = FindAnyObjectByType<GameManagerCLASS>();
        bool isPlaying = gameManager.isPlaying;

        if (isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                //remove from list
                items.Remove(items[0]);
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                //sort list
                Debug.Log("Sorted");
                items.Sort();
            }
        }
    }
}

