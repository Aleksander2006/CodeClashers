using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UIElements;

public class Lever : MonoBehaviour
{
        //private GameObject Lampje1;
        //private GameObject Lever2;
        //private GameObject Lever4;
            public Transform Lever1;
            
            public Transform Lever2;

            public Transform Lampje1;
            public Transform Lampje2;

        //Hendel weg- UIT
            public float zValue = 1f;
        //Hendel komt-AAN
            public float zValue2 = -1f;

            private bool isLeverOn = false;
            private bool IsCharacterInside = false;

            //Lampje uit-weg
            private GameObject lever;
            

            void Start(){
            Lever1.GetComponent<Transform>();
            Lever2.GetComponent<Transform>();
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
                            Debug.Log("Hij staat Aan");
                            Vector3 newPosition1 = new Vector3(Lever1.position.x, Lever1.position.y, zValue);
                            Lever1.position = newPosition1;

                            Vector3 newPosition2 = new Vector3(Lever2.position.x, Lever2.position.y, zValue2);
                            Lever2.position = newPosition2;
                            lever.SetActive(true);
                            
                                
                        }
                        //Wanneer die uit aan staat en uit moet
                        else {
                            Debug.Log("Hij staat Uit");
                            Vector3 newPosition1 = new Vector3(Lever1.position.x, Lever1.position.y, zValue2);
                            Lever1.position = newPosition1;

                            Vector3 newPosition2 = new Vector3(Lever2.position.x, Lever2.position.y, zValue);
                            Lever2.position = newPosition2;
                            lever.SetActive(false);             
                        }
                
                }
        }

            isLeverOn = !isLeverOn;

                    

            if(!isLeverOn){

                    Vector3 newPosition1 = new Vector3(Lampje1.position.x, Lampje1.position.y, zValue);
                    Lampje1.position = newPosition1;

                    Vector3 newPosition2 = new Vector3(Lampje2.position.x, Lampje2.position.y, zValue2);
                    Lampje2.position = newPosition2;

                }    
            
        }   
    }
