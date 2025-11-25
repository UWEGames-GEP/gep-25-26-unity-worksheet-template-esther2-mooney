using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public string itemName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemName = this.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, Time.timeScale * 1f, 0f, Space.Self);
    }
}
