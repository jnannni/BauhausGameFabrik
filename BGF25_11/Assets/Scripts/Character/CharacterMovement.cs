using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public enum PlayerState
    {
        walk,
        interact,
        fly,
        cut_scene
    }

    public Rigidbody2D rb;
    private Vector2 movement;
    public float speed = 5f;
    public Animator animator;
    [SerializeField] private BoolValue isDialogueRunning;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isDialogueRunning", isDialogueRunning.initialValue);
        movement = Vector2.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (!isDialogueRunning.initialValue && movement != Vector2.zero)
        {
            Movement();
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void Movement()
    {
        movement.Normalize();
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
