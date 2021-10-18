using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this script should hold all the information to be accessed by all characters
public abstract class JAHCharacter : MonoBehaviour
{
    [SerializeField] private float speed;

    private Animator anim;

    protected Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        AnimateMovement();
    }

    public void AnimateMovement()
    {
        

        Animate(direction);
    }

    public void Animate(Vector2 direction)
    {
        anim.SetFloat("x", direction.x);
        anim.SetFloat("y", direction.y);
    }
}
