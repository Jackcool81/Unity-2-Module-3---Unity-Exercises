using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryScript : MonoBehaviour
{
    public GameObject textPrefab;
    public GameObject inventoryPanel;
    public GameObject content;

    bool inventoryShowing = false;

    public List<InvItem> inventory; 

    // END OF CODE

    void Start()
    {
        inventoryShowing = false;
        inventoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(inventoryShowing)
            {
                inventoryShowing = false;
                inventoryPanel.SetActive(false);
            }
            else
            {
                inventoryShowing = true;
                inventoryPanel.SetActive(true); 
                UpdateInventory();
            }
        }
    }

    public void DeleteOldItems()
    {
        var items = new List<GameObject>();
        foreach (Transform item in content.transform) items.Add(item.gameObject);
        items.ForEach(item => Destroy(item));
    }

    public void UpdateInventory()
    {
        DeleteOldItems();
        foreach (InvItem item in inventory) {
            GameObject invText = Instantiate(textPrefab);
            invText.transform.SetParent(content.transform);
            invText.GetComponent<TextMeshProUGUI>().SetText(item.invName);

        }

        // END OF CODE
    }

    private void OnTriggerEnter(Collider other) 
    {
        
        if (other.GetComponent<InvItem>() != null) 
        {
            inventory.Add(other.GetComponent<InvItem>());
            other.gameObject.SetActive(false);
        }
    }
}
