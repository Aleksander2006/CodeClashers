using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class MovementScript : MonoBehaviour {
    
    public float MoveSpeed = 5f;
    public Rigidbody2D RigidBodyLink;
    public Animator animator;
    Vector2 movement;

    public AudioSource audioSource;

    void Update() {
        //keyboard input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;

        //movement output
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x > 0.01 || movement.y > 0.01 || movement.sqrMagnitude > 0.01) {
        
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        } 
        else {
            audioSource.Stop();
        }
    }

    void FixedUpdate() {
        //movement systeem
        RigidBodyLink.MovePosition(RigidBodyLink.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }
}
