using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhysicalInvetoryItem : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryItem item;
    private bool isPressed;
    private bool isItemClose;
    public Animator animator;
    [SerializeField] private string pickedUpAnim = "PickedUp";

    private void Start()
    {
        isPressed = false;
        isItemClose = false;
        //animator.SetBool("isPickedUp", false);
    }

    private void Update()
    {        
        isPressed = Input.GetKeyDown(KeyCode.J);
        if (isPressed && isItemClose)
        {
            Debug.Log(item.name);
            FindObjectOfType<AudioManager>().Play("Item_PickUp");
            AddItemToInventory();
            animator.Play("PickedUp", 0, 0f);           
            Destroy(this.gameObject);
            if (item.name == "Key")
            {
                SceneManager.LoadScene("DreamWorld");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isItemClose = true;
            
        }
    }

    IEnumerator PickUpAnimation()
    {       
        yield return new WaitForSeconds(animator.runtimeAnimatorController.animationClips[0].length * 1/animator.runtimeAnimatorController.animationClips[0].apparentSpeed);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            isItemClose = false;
        }
    }

    void AddItemToInventory()
    {
        if (playerInventory && item)
        {
            playerInventory.myInventory.Add(item);
        }
    }
}
