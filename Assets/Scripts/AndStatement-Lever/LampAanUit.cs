using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampAanUit : MonoBehaviour, ILever
{
    public GameObject Lampje1;
    
    public Lever_1 lever1script;
    public Lever_2 lever2script;

    void Start()
    {
        //lever1script = GameObject.
    }

    // Update is called once per frame
    void Update()
    {
      //beide levers moeten aanstaan om het lampje te laten branden
        //if(!isLeverOn && !isLeverOn2){
//
        //    //Grijs lampje gaat weg,
        //    Lampje1.SetActive(false);
        //    Debug.Log("Lamp AAN");
//
        //} else {
        //     
        //    //Grijs lampje blijf
        //    Lampje1.SetActive(true);
        //    Debug.Log("Lamp UIT");      
        //}  
    }
}
