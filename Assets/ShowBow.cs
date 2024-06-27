using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBow : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);

        if (StaticData.lvl1Completed == true)
        {
            gameObject.SetActive(true);
        }
    }
}

