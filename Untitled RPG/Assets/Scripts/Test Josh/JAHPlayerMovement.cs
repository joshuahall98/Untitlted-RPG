using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JAHPlayerMovement : MonoBehaviour
{
    private PlayerInputControl playerInput;
    private Rigidbody2D rb;

    //Allows visibility to Editor as Private
    [SerializeField] private float speed = 2.5f;

    private bool isWalking;

    private Animator anim;

    void Awake()
    {

        playerInput = new PlayerInputControl();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        
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

        float xaxis = moveInput.x;
        float yaxis = moveInput.y;

        if(xaxis != 0 || yaxis != 0)
        {
            anim.SetFloat("Horizontal", xaxis);
            anim.SetFloat("Vertical", yaxis);
            if (!isWalking)
            {
                isWalking = true;
                anim.SetBool("isMoving", isWalking);
            }
            
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                anim.SetBool("isMoving", isWalking);
            }
        }
        
    }

    
}
