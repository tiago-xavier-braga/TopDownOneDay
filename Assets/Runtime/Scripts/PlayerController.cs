using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 400;
    [SerializeField] private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator animator;
    private PlayerInputActions inputActions;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Enable();
    }

    void Update()
    {
        moveInput = inputActions.PlayerControls.Movement.ReadValue<Vector2>();
        
        if (moveInput == new Vector2(-1, 0))
        {
            animator.SetBool("isLeft", true);
            animator.SetBool("isStopped", false);
        } 
        else if (moveInput == new Vector2(1, 0))
        {
            animator.SetBool("isRight", true);
            animator.SetBool("isStopped", false);
        }
        else if (moveInput == new Vector2(0, 1))
        {
            animator.SetBool("isBack", true);
            animator.SetBool("isStopped", false);
        }
        else if (moveInput == new Vector2(0, -1))
        {
            animator.SetBool("isFront", true);
            animator.SetBool("isStopped", false);
        }
        else if (moveInput == new Vector2(0, 0))
        {
            animator.SetBool("isStopped", true);
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", false);
            animator.SetBool("isBack", false);
            animator.SetBool("isFront", false);
        }

        rb.velocity = moveInput * speed * Time.deltaTime;
    }
}
