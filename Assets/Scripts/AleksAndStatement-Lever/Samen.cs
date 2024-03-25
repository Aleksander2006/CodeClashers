using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samen : MonoBehaviour
{
    public GameObject Lucas;
    public GameObject Aleks;
    public GameObject lampjeCheck;

    

    // Start is called before the first frame update
    void Start()
    { 
           
    }

    // Update is called once per frame
    void Update()
    {
        
       if(Lucas && Aleks == true){
        
        lampjeCheck.SetActive(false);

       } 
    }
}