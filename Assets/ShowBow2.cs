using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBow2 : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);

        if (StaticData.floatToKeep == "teleporter_4a")
        {
            gameObject.SetActive(true);
        }
    }
}


