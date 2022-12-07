using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public enum NPCState
    {
        idle,
        talk
    }
    
    public GameObject target;
    private bool isPressed;
    private float distance;
    public float minDist = 0.5f;
    public NPCState npcState;
    public string npcName;    
    public bool interactable;
    [SerializeField]private string dialogueStartingNode;

    private void Start()
    {
        isPressed = false;
    }

    void Update()
    {
        isPressed = Input.GetKeyDown(KeyCode.K);
        distance = Vector2.Distance(target.transform.position, this.gameObject.transform.position);
        if (distance < minDist)
        {
            //Debug.Log("interactable");
        }
        Interact();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayVoice();
            Debug.Log("Start One Animation");
        }
    }

    public void Interact()
    {
        if (distance < minDist && isPressed)
        {
            Debug.Log("interaction");
        }
    }

    public void PlayVoice()
    {
        if (this.gameObject.CompareTag("NPC_DreamWorld"))
        {
            FindObjectOfType<AudioManager>().PlayNPCVoice();
        }
    }
}
