using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_1 : MonoBehaviour
{
    public GameObject lever1; 
    public bool isLeverOn = true;
    private bool IsCharacterInside = false;

    void Start(){
        lever1.GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Character") { // Checkt of de Character in de Trigger zit
            Debug.Log("Inside");
            IsCharacterInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Character") {  // Checkt of de Character uit de Trigger gaat
            Debug.Log("Outside");
            IsCharacterInside = false;
        }
    }

    void Update() {
        if (IsCharacterInside){
            if(Input.GetKeyDown(KeyCode.E)) { // Gebruik de toets 'E' voor lever1
                Debug.Log("E key pressed");
                if(!isLeverOn) { // Als de lever false is, run de code

                    Debug.Log("Lever 1 staat UIT");
                    lever1.transform.localRotation = Quaternion.Euler(0, 180, 180);
                    isLeverOn = false;

                } else { // Als de lever true is, run deze code
        
                    Debug.Log("Lever 1 staat AAN");
                    lever1.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    isLeverOn = true;
                }
                isLeverOn = !isLeverOn; // Als de if statement is gerunt, draai de boolean waarde van isLeverOn om
            }
        }
    }
}