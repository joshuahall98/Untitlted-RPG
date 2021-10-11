using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //private PlayerInputActions controller;
    private Rigidbody2D rb; 

    [SerializeField] public float speed = 10f;

    // Start is called before the first frame update
    void Awake()
    {
        //controller = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
    }

    /*private void OnEnable(){
        controller.Enable();
    }

    private void OnDisable(){
        controller.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveInput = controller.Movement.Move.ReadValue<Vector2>();
        rb.velocity = moveInput * speed;
    }*/
}