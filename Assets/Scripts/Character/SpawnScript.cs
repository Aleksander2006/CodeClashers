using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    private string spawnLocation;

    [SerializeField] GameObject teleporter_0a;
    [SerializeField] GameObject teleporter_1a;
    [SerializeField] GameObject teleporter_1b;
    [SerializeField] GameObject teleporter_1c;
    [SerializeField] GameObject teleporter_1d;
    [SerializeField] GameObject teleporter_2a;
    [SerializeField] GameObject teleporter_2b;
    [SerializeField] GameObject teleporter_3a;
    [SerializeField] GameObject teleporter_3b;
    [SerializeField] GameObject teleporter_4a;
    

    //Level 3 moet nog hieronder, maar we hebben die nog niet...//

    void Start(){
        string newValue = StaticData.floatToKeep;
        spawnLocation = newValue;
        StaticData.floatToKeep = spawnLocation;

        if(spawnLocation == "teleporter_0a") {
            gameObject.transform.position = teleporter_1a.transform.position + new Vector3(-0.83f, -2.6f, -3.59f);
        } 

        if(spawnLocation == "teleporter_1a") {
            gameObject.transform.position = teleporter_0a.transform.position + new Vector3(0, 3, -5);
        } 

        if(spawnLocation == "teleporter_1b") {
            gameObject.transform.position = teleporter_2a.transform.position + new Vector3(0, 1.2f, -5);
        } 

        if(spawnLocation == "teleporter_1c") {
            gameObject.transform.position = teleporter_3a.transform.position + new Vector3(0, 1.2f, -5);
        } 

        if(spawnLocation == "teleporter_1d") {
            gameObject.transform.position = teleporter_4a.transform.position + new Vector3(0, 1.2f, -5);
        } 

        if(spawnLocation == "teleporter_2a") {
            gameObject.transform.position = teleporter_1b.transform.position + new Vector3(-0.93f, -2.7f, -3.59f);
        } 

        if(spawnLocation == "teleporter_2b") {
            gameObject.transform.position = teleporter_1b.transform.position + new Vector3(-0.93f, -2.7f, -3.59f);
            StaticData.lvl1Completed = true;
        } 

        if(spawnLocation == "teleporter_3a") {
            gameObject.transform.position = teleporter_1c.transform.position + new Vector3(-0.93f, -2.7f, -3.59f);
        } 

        if(spawnLocation == "teleporter_4a") {
            gameObject.transform.position = teleporter_1c.transform.position + new Vector3(-0.93f, -2.7f, -3.59f);
            StaticData.lvl2Completed = true;
        } 
    }

    void Update() {
        Debug.Log(spawnLocation);
    }
}