using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBow2 : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);

        if (StaticData.lvl2Completed == true)
        {
            gameObject.SetActive(true);
        }
    }
}


