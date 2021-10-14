using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSEnemyAI : MonoBehaviour
{

    public Animator anim;
    public float distStop;
    public float speed;

    //Line of Sight Variable
    public float lineOfSightDist;

    //Randomise Patrol Variables

    public float startWaitTime;
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

        waitTime = startWaitTime;
        moveSpot.position = new Vector2(UnityEngine.Random.Range(minX, maxX), UnityEngine.Random.Range(minY, maxY));
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


    }
    private void Update()
    {

        //Line of Sight
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, moveSpot.position, lineOfSightDist);
        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + moveSpot.position * lineOfSightDist, Color.green);
        }

        //Follow Player endlessly
        // transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                moveSpot.position = new Vector2(UnityEngine.Random.Range(minX, maxX), UnityEngine.Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }

    }
}

