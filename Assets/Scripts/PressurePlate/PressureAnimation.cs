using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureAnimation : MonoBehaviour
{
    [SerializeField] private Animator PressureController;
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Character")){
            PressureController.SetBool("AnimPlayer", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.CompareTag("Character")){
            PressureController.SetBool("AnimPlayer", false);
        }
    }
}
