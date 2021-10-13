using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    private PlayerInputControl playerInput;
    Rigidbody2D rb;

    //Allows visibility to Editor as Private
    [SerializeField] private float speed = 10f;

    void Awake()
    {

        playerInput = new PlayerInputControl();
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
    void FixedUpdate()
    {

        Vector2 moveInput = playerInput.Movement.Move.ReadValue<Vector2>();
        rb.velocity = moveInput * speed;

    }
}
