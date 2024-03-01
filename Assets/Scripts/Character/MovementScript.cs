using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float MoveSpeed = 5f;

    public Rigidbody2D RigidBodyLink;

    public Animator animator;

    Vector2 movement; 

    // Update is called once per frame
    void Update()
    {
        //keyboard input 
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        //movement system
        //Dit stuk kennis heb ik opgedaan uit zowel de flappybird cursus als een yt vid.
        RigidBodyLink.MovePosition(RigidBodyLink.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }
}    

//53345
