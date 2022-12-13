using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ObjectInteractable : MonoBehaviour
{
    private DialogueRunner dialogueRunner;
    private bool isCurrentConversation = false;   
    [SerializeField] private InventoryItem item;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private string dialogueStartingNode;    

    public bool collectable;
    public GameObject target;    
    private float distance;
    public float minDist = 0.5f;
    private bool toInteract;
    private bool isPressed;

    private void Start()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        dialogueRunner.onDialogueComplete.AddListener(EndConversation);
        toInteract = false;
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        isPressed = Input.GetKeyDown(KeyCode.K);
        distance = Vector2.Distance(target.transform.position, this.gameObject.transform.position);
        if (distance < minDist)
        {
            toInteract = true;
            //Debug.Log("interactable");
        }
        else toInteract = false;
        Interact();
    }

    public void Interact()
    {
        if (distance < minDist && isPressed)
        {
            StartConversation();
            if (item && playerInventory && !collectable)
            {
                playerInventory.myInventory.Add(item);
                Destroy(this.gameObject);
            }
        }
    }

    private void StartConversation()
    {
        Debug.Log($"Started conversation with {name}.");
        //isDialogueRunning.initialValue = true;
        isCurrentConversation = true;
        dialogueRunner.StartDialogue(dialogueStartingNode);
    }

    private void EndConversation()
    {
        if (isCurrentConversation)
        {
            //isDialogueRunning.initialValue = false;
            isCurrentConversation = false;
            Debug.Log($"Started conversation with {name}.");
        }
    }

}
