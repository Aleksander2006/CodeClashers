using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampAanUit : MonoBehaviour 
{
    [SerializeField] private GameObject doorGameObject;
    private IDoor door;

    //IDoor in het gemaakte object zetten zodat het gelinkt is
    private void Awake() {
        door = doorGameObject.GetComponent<IDoor>();
    }
    [SerializeField] private GameObject Lampje1;
    [SerializeField] private GameObject Lever1;
    [SerializeField] private GameObject Lever3;

    public Lever_1 lever1Script; //Script lever 1 waar ik de isLeverOn variabele uit wil halen
    public Lever_2 lever2Script; //Script lever 3 waar ik de isLeverOn2 variabele uit wil halen

    void Start()
    {
        lever1Script = Lever1.GetComponent<Lever_1>(); //Script lever 1 waar ik de isLeverOn variabele uit wil halen
        lever2Script = Lever3.GetComponent<Lever_2>(); //Script lever 3 waar ik de isLeverOn2 variabele uit wil halen
    }

    void Update()
    {
        Debug.Log("Lever 1 status: " + lever1Script.isLeverOn);
        Debug.Log("Lever 2 status: " + lever2Script.isLeverOn2);

        //Beide levers moeten aanstaan om het lampje te laten branden
        if(lever1Script.isLeverOn == false && lever2Script.isLeverOn2 == false){

            //Grijs lampje gaat weg
            Lampje1.SetActive(false);
            
            Debug.Log("Lamp AAN");
            door.DoorSignal1();

        } else {

            //Grijs lampje blijft
            Lampje1.SetActive(true);

            Debug.Log("Lamp UIT");
            door.DoorSignalClose1();
        }
    }
}