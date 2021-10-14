using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSEnemyAI : MonoBehaviour
{

    public Animator anim;
    public float distStop;
    public float speed;

    //Randomise Patrol Variables

    private float startWaitTime;
    private float waitTime;
    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Transform target;

    //define states for the animation
    public enum State { aggressive, passive }
    //action variable to grap a certain anim state
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

        startWaitTime = UnityEngine.Random.Range(1, 3);
        waitTime = startWaitTime;

        moveSpot.position = new Vector2(UnityEngine.Random.Range(minX, maxX), UnityEngine.Random.Range(minY, maxY));
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


    }
    private void Update()
    {
       
        //Follow Player endlessly
        // transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            

            if (waitTime <= 0)
            {
                moveSpot.position = new Vector2(UnityEngine.Random.Range(minX, maxX), UnityEngine.Random.Range(minY, maxY));
                startWaitTime = UnityEngine.Random.Range(1, 3);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }

    }
}

