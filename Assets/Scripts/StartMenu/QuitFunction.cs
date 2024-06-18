using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuitFunction : MonoBehaviour
{
    public void ExitGame(){
        Application.Quit();
        Debug.Log("Exit");
    }
}


