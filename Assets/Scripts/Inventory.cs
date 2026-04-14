using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.Rendering;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    public List<ItemObject> items = new List<ItemObject>();

    public GameManager gameManager;
    public AudioSource source;
    public AudioClip clip;
    public GameObject itemContainer;
    public bool gotAll = false;
    private void AddItem(ItemObject collisionItem)
    {
        items.Add(collisionItem);
        source.PlayOneShot(clip);
    }
    
    public void RemoveItem(int i)
    {
        ItemObject collisionItem = items[0];
        if ( i < items.Count)
        {
            collisionItem = items[i];
        }

        Vector3 newPostion = transform.position + transform.forward + new Vector3(0, 1, 0);
        Quaternion newRotation = transform.rotation * Quaternion.Euler(0, 0, 0);

        collisionItem.gameObject.SetActive(true);
        collisionItem.gameObject.transform.position = newPostion;
        collisionItem.gameObject.transform.rotation = newRotation;

        items.Remove(collisionItem);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        gotAll = false;
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        ItemObject collisionItem = hit.gameObject.GetComponent<ItemObject>();
        if (collisionItem != null)  
        {
            if (collisionItem.gameObject.activeSelf == true)
            {
                AddItem(collisionItem);
                collisionItem.gameObject.SetActive(false);
            }
        }
    }
    private void Update()
    {
        if (itemContainer.transform.childCount == 0 && !gotAll)
        {
            Debug.Log("got all");
            gotAll = true;
        }
    }
}

