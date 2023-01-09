using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 400;
    [SerializeField] private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator animator;
    private PlayerInputActions inputActions;
    private Vector2 playerPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Enable();
        playerPosition = this.transform.position;
        inputActions.PlayerControls.Menu.performed += onMenuInput;
    }

    private void onMenuInput(InputAction.CallbackContext obj)
    {
        Debug.Log("Open Menu");
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(playerPosition);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Vector2 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];

        transform.position = position;

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
        playerPosition = this.transform.position;
    }
}
