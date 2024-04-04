using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupActivater : MonoBehaviour, IPopup {
    public void Start(){
        gameObject.SetActive(false);
    }
    public void ShowPopup() {
        gameObject.SetActive(true);
    }
    public void HidePopup() {
        gameObject.SetActive(false);
    }
}
