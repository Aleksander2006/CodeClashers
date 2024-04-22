using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lampje4AanUit : MonoBehaviour
{
    public GameObject Lampje4;
    public GameObject Lever4;

    public Lever_4 lever4Script;

    void Start()
    {
        lever4Script = Lever4.GetComponent<Lever_4>();
    }

    void Update()
    {
        Debug.Log("Lever 4 status: " + lever4Script.isLeverOn4);

        // Controleer alleen de status van Lever4
        if (lever4Script.isLeverOn4)
        {
            Lampje4.SetActive(true); // Schakel Lampje4 in
        }
        else
        {
            Lampje4.SetActive(false); // Schakel Lampje4 uit
        }
    }
}
