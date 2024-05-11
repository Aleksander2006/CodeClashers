using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigPopupTrigger : MonoBehaviour {
    [SerializeField] private GameObject popupGameObject;
    private IPopup popup;

    //Ipopup in het gemaakte object zetten zodat het gelinkt is
    private void Awake() {
        popup = popupGameObject.GetComponent<IPopup>();
    }

    private void OnTriggerEnter2D(Collider2D interactCollider) {
        if (interactCollider.GetComponent<MovementScript>() != null){
            popup.ShowPopup();
        }
    }
    private void OnTriggerExit2D(Collider2D interactCollider) {
        if (interactCollider.GetComponent<MovementScript>() != null){
            popup.HidePopup();
        }
    }
}
