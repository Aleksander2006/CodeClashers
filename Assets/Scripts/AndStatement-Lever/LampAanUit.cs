using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampAanUit : MonoBehaviour 
{
    public GameObject Lampje1;
    public Lever_1 lever1Script;
    public Lever_2 lever2Script;

    void Start()
    {
        lever1Script = GameObject.FindWithTag("Lever1").GetComponent<Lever_1>();
        lever2Script = GameObject.FindWithTag("Lever3").GetComponent<Lever_2>();   
    }

    
    void Update()
    {
        //beide levers moeten aanstaan om het lampje te laten branden
        if(lever1Script.isLeverOn == false && lever2Script.isLeverOn2 == false){

            //Grijs lampje gaat weg
            Lampje1.SetActive(false);
            Debug.Log("Lamp AAN");

        } else {

            //Grijs lampje blijft
            Lampje1.SetActive(true);
            Debug.Log("Lamp UIT");      
        } 
    }
}
