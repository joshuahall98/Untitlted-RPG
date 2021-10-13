using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSEnemyAI : MonoBehaviour
{

    public Animator anim;
    public float speed;

    private Transform target;

    public enum State { aggressive, passive }
    public State action = State.passive;

    private void Start()
    {
        //get Animator component from object
        anim.GetComponent<Animator>();
        //sets state to aggressive
        action = State.aggressive;
        //sets state to passive
        //action = State.passive;
        //sets anim to desired action
        anim.SetInteger("State", (int)action);

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        
    }
    private void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        
    }
}
