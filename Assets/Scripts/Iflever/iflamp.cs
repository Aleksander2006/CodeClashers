using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iflamp : MonoBehaviour, Ilamp
{
    [SerializeField] private GameObject doorGameObject;

    private IDoor door;

    private void Awake()
    {
        door = doorGameObject.GetComponent<IDoor>();
    }

    private bool isLeverOn4 = false;

    public IDoor Door { get => door; set => door = value; }

    public void leverOnSignal4()
    {
        if (!isLeverOn4)
        {
            isLeverOn4 = true;
            Debug.Log("Lever4 = TRUE");
        }
    }

    public void leverOffSignal4()
    {
        if (isLeverOn4)
        {
            isLeverOn4 = false;
            Debug.Log("Lever4 = FALSE");
        }
        gameObject.SetActive(true);
    }

    public void Update()
    {
        if (isLeverOn4)
        {
            gameObject.SetActive(false);
            Door.DoorSignal4(); // Make sure IDoor has DoorSignal4 method
            Debug.Log("lamp4 AAN");
        }
        else
        {
            gameObject.SetActive(true);
            Debug.Log("lamp4 UIT");
            Door.DoorSignalClose1();
        }
    }

    public void leverOnSignal1()
    {
        throw new System.NotImplementedException();
    }

    public void leverOnSignal2()
    {
        throw new System.NotImplementedException();
    }

    public void leverOffSignal1()
    {
        throw new System.NotImplementedException();
    }

    public void leverOffSignal2()
    {
        throw new System.NotImplementedException();
    }

    // Implement other methods from Ilamp interface if needed
}
