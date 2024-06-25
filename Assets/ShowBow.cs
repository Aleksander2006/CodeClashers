using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBow : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);

        if (StaticData.floatToKeep == "teleporter_2b" || StaticData.floatToKeep == "teleporter_3a" || StaticData.floatToKeep == "teleporter_4a")
        {
            gameObject.SetActive(true);
        }
    }
}

