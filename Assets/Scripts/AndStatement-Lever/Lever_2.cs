using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_2 : MonoBehaviour 
{
    public GameObject lever3;
    public bool isLeverOn2 = true;
    private bool IsCharacterInside = false;

    void Start(){
        lever3.GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Character") { // Checkt of de Character in de Trigger zit
            Debug.Log("Inside");
            IsCharacterInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Character") { // Checkt of de Character uit de Trigger gaat
            Debug.Log("Outside");
            IsCharacterInside = false;
        }
    }

    void Update() {
        if (IsCharacterInside){
            if(Input.GetKeyDown(KeyCode.E)) { // Gebruik de toets 'E' voor lever3
                Debug.Log("E key pressed");
                if(!isLeverOn2) { // Als de lever false is, run de code

                    Debug.Log("Lever 2 staat UIT");
                    lever3.transform.localRotation = Quaternion.Euler(0, 180, 180);
                    isLeverOn2 = false;

                } else { // Als de lever true is, run deze code

                    Debug.Log("Lever 2 staat AAN");
                    lever3.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    isLeverOn2 = true;
                }
                isLeverOn2 = !isLeverOn2; // Als de if statement is gerunt, draai de boolean waarde van isLeverOn2 om
            }
        }
    }
}