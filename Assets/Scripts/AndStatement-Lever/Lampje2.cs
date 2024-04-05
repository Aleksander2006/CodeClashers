using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lampje2 : MonoBehaviour
{
    public GameObject Lampje1;

    public GameObject Lever1;

    public GameObject Lever3;

    public Lever_1 lever1Script;
    public Lever_2 lever2Script;

    void Start()
    {
        lever1Script = Lever1.GetComponent<Lever_1>();
        lever2Script = Lever3.GetComponent<Lever_2>();  
    }

    void Update()
    {
          
        Debug.Log("Lever 1 status: " + lever1Script.isLeverOn);
        Debug.Log("Lever 2 status: " + lever2Script.isLeverOn2);

        //beide levers moeten aanstaan om het lampje te laten branden
        if (lever1Script.isLeverOn == true || lever2Script.isLeverOn2 == true)
        {
            //Grijs lampje gaat weg
            Lampje1.SetActive(true);
            Debug.Log("Lamp UIT");  
        }   
    }
}
