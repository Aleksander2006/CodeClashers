using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever2 : MonoBehaviour
{
            public Transform Lever3;
            
            public Transform Lever4;

            public Transform Lampje1;
            public Transform Lampje2;

        //Hendel weg- UIT
            public float zValue = 1f;
        //Hendel komt-AAN
            public float zValue2 = -1f;

            private bool isLeverOn = false;
            private bool IsCharacterInside = false;

            //Lampje uit-weg
            //private GameObject lever;
            

            void Start(){
            Lever3.GetComponent<Transform>();
            Lever4.GetComponent<Transform>();
            }

            void OnTriggerEnter2D(Collider2D other) {
                if(other.tag == "Character") {
                Debug.Log("Inside");
                IsCharacterInside = true;
                }
            }

            void OnTriggerExit2D(Collider2D other) {
                if(other.tag == "Character") {
                Debug.Log("Outside");
                IsCharacterInside = false;
                }
            }
            
 void Update() {

        if (IsCharacterInside){
            if(Input.GetKeyDown(KeyCode.E)) { 
                if(isLeverOn)
                        {
                        //Wanneer die uitstaat en aanmoet
                            Debug.Log("Lever 3-4 Hij staat Aan");
                            Vector3 newPosition1 = new Vector3(Lever3.position.x, Lever3.position.y, zValue);
                            Lever3.position = newPosition1;

                            Vector3 newPosition2 = new Vector3(Lever4.position.x, Lever4.position.y, zValue2);
                            Lever4.position = newPosition2;
                            //lever.SetActive(true);
                            
                                
                        }
                        
                        //Wanneer die uit aan staat en uit moet
                        else {
                            Debug.Log("Lever 3-4 Hij staat Uit");
                            Vector3 newPosition1 = new Vector3(Lever3.position.x, Lever3.position.y, zValue2);
                            Lever3.position = newPosition1;

                            Vector3 newPosition2 = new Vector3(Lever4.position.x, Lever4.position.y, zValue);
                            Lever4.position = newPosition2;
                            //lever.SetActive(false);             
                        }        

                }
        }

            isLeverOn = !isLeverOn;
                         
        }   
    }
