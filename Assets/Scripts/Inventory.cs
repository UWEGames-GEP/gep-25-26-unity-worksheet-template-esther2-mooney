using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.Rendering;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    //private List<ItemObject> itemObjects = new List<ItemObject>();
    public List<ItemObject> items = new List<ItemObject>();
    private string[] random_loot = { "Gold", "Silver", "Diamond", "Sword", "Axe", "Bow", "Copper", "Potion", "Bomb", "Crystal" };

    public GameManager gameManager;
    Transform worldItemsTransform;
    private ItemObject hit;
    public AudioSource source;
    public AudioClip clip;
    public GameObject itemContainer;
    public bool gotAll = false;
    private void AddItem(ItemObject collisionItem)
    {
        items.Add(collisionItem);        
        Debug.Log(collisionItem.name);
    }
    public void RemoveItem(ItemObject collisionItem)
    {
        Vector3 currentPosition = transform.position;
        Vector3 forward = transform.forward;

        Vector3 newPostion = currentPosition + forward;
        newPostion += new Vector3(0, 1, 0);

        Quaternion currentRotation = transform.rotation;
        Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 0);


        GameObject newItem = Instantiate(collisionItem.gameObject, newPostion, newRotation, worldItemsTransform);
        newItem.name = newItem.name.Remove(newItem.name.Length - 7);
        newItem.SetActive(true);

        items.Remove(collisionItem);
        Destroy(collisionItem.gameObject);
    }

    public void RemoveItem(int i)
    {
        if ( i < items.Count)
        {
            RemoveItem(items[i]); 
        }
    }

    public void RemoveItem() 
    {
        if (gameManager.game.state == GameState.StateENUM.GAMEPLAY && items.Count >0)
        {
            ItemObject item = items[0];
            RemoveItem(item);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        gotAll = false;
        gameManager = FindAnyObjectByType<GameManager>();
      //  Transform worldItemsTransform = GameObject.Find("WorldItems").transform;
    }

    // Update is called once per frame
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        ItemObject collisionItem = hit.gameObject.GetComponent<ItemObject>();
        if (collisionItem != null)  
        {
            AddItem(collisionItem);
            source.PlayOneShot(clip);
            collisionItem.gameObject.SetActive(false);
                
        }
    }
    private void Update()
    {
        if (gameManager.game.state == GameState.StateENUM.GAMEPLAY)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                //sort list
                Debug.Log("Sorted");
                items.Sort();
            }
        }
        if (itemContainer.transform.childCount == 0 && !gotAll)
        {
            Debug.Log("got all");
            gotAll = true;
        }


    }
}

