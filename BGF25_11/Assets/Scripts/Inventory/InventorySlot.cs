using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventorySlot : MonoBehaviour
{
    [Header("UI Stuff to change")]    
    [SerializeField] private Image itemImage;

    [Header("Variables from the item")]
    public InventoryItem thisItem;
    public InventoryManager thisManager;

    public void Setup(InventoryItem newItem, InventoryManager newManager)
    {
        thisItem = newItem;
        thisManager = newManager;
        if (thisItem && SceneManager.GetActiveScene().name == "SampleScene")
        {
            itemImage.sprite = thisItem.itemImage;
        } else if (thisItem && SceneManager.GetActiveScene().name == "DreamWorld")
        {
            itemImage.sprite = thisItem.itemImageDW;
        }
    }

    public void ClickedOn()
    {
        Debug.Log("click");
        if (thisItem)
        {
            thisManager.SetupDescriptionAndButton(thisItem.itemDescription, thisItem.usable, thisItem);
        }
    }
}
