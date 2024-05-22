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
            gameObject.transform.position = teleporter_1a.transform.position + new Vector3(0, -1.5f, 0);
        } 

        if(spawnLocation == "teleporter_1a") {
            gameObject.transform.position = teleporter_1a.transform.position + new Vector3(0, -1.5f, 0);
        } 

        if(spawnLocation == "teleporter_1b") {
            gameObject.transform.position = teleporter_1a.transform.position + new Vector3(0, -1.5f, 0);
        } 

        if(spawnLocation == "teleporter_1c") {
            gameObject.transform.position = teleporter_1a.transform.position + new Vector3(0, -1.5f, 0);
        } 

        if(spawnLocation == "teleporter_1d") {
            gameObject.transform.position = teleporter_1a.transform.position + new Vector3(0, -1.5f, 0);
        } 

        if(spawnLocation == "teleporter_2a") {
            gameObject.transform.position = teleporter_1a.transform.position + new Vector3(0, -1.5f, 0);
        } 

        if(spawnLocation == "teleporter_2b") {
            gameObject.transform.position = teleporter_1a.transform.position + new Vector3(0, -1.5f, 0);
        } 

        if(spawnLocation == "teleporter_3a") {
            gameObject.transform.position = teleporter_1a.transform.position + new Vector3(0, -1.5f, 0);
        } 

        if(spawnLocation == "teleporter_3b") {
            gameObject.transform.position = teleporter_1a.transform.position + new Vector3(0, -1.5f, 0);
        } 

        if(spawnLocation == "teleporter_4a") {
            gameObject.transform.position = teleporter_1a.transform.position + new Vector3(0, -1.5f, 0);
        } 
    }

    void Update() {
        Debug.Log(spawnLocation);
    }
}