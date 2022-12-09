using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Information")]
    public PlayerInventory playerInventory;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject useButton;
    public InventoryItem currentItem;    

    public void SetTextAndButton(string description, bool isActive)
    {
        descriptionText.text = description;
        if (isActive)
        {
            useButton.SetActive(true);
        } else useButton.SetActive(false);
    }

    void MakeInventorySlots()
    {
        if (playerInventory)
        {
            for (int i = 0; i < playerInventory.myInventory.Count; i++)
            {
                GameObject temp = Instantiate(blankInventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                temp.transform.SetParent(inventoryPanel.transform);
                InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                if (newSlot)
                {
                    newSlot.Setup(playerInventory.myInventory[i], this);
                }                
            }
        }
    }
    
    void OnEnable()
    {
        ClearInventorySlots();
        MakeInventorySlots();
        SetTextAndButton("", false);        
    }

    private void Update()
    {
        if (currentItem && currentItem.isUsed)
        {
            useButton.GetComponentInChildren<TextMeshProUGUI>().text = "Used";
        }
        else
        {
            useButton.GetComponentInChildren<TextMeshProUGUI>().text = "Use";
        }
    }

    void ClearInventorySlots()
    {
        for (int i = 0; i < inventoryPanel.transform.childCount; i++)
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }

    public void SetupDescriptionAndButton(string newDescription, bool isUsable, InventoryItem newItem)
    {
        currentItem = newItem;
        descriptionText.text = newDescription;
        useButton.SetActive(isUsable);        
    }

    public void useButtonPressed()
    {
        if (currentItem)
        {
            currentItem.Use();
        }
    }
}
