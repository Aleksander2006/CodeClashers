using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampSwitch : MonoBehaviour, Ilamp
{
    [SerializeField] private GameObject doorGameObject;
    [SerializeField] private GameObject ANDGateGameObject;

    private IDoor door;

    private bool isLeverOn1 = false;
    private bool isLeverOn2 = false;

    private void Awake()
    {
        door = doorGameObject.GetComponent<IDoor>();
    }

    private void Start()
    {
        ANDGateGameObject.SetActive(false);
    }

    public void leverOnSignal1()
    {
        isLeverOn1 = true;
        Debug.Log("Lever1 = TRUE");
    }

    public void leverOnSignal2()
    {
        isLeverOn2 = true;
        Debug.Log("Lever2 = TRUE");
    }

    public void leverOffSignal1()
    {
        isLeverOn1 = false;
        Debug.Log("Lever1 = FALSE");
    }

    public void leverOffSignal2()
    {
        isLeverOn2 = false;
        Debug.Log("Lever2 = FALSE");
    }

    public void Update()
    {
        if (isLeverOn1 && isLeverOn2)
        {
            gameObject.SetActive(false);
            ANDGateGameObject.SetActive(true);
            door.DoorSignal1(); // Assuming DoorSignal1 corresponds to the combined signal of lever 1 and 2
            Debug.Log("lamp1 AAN");
        }
        else
        {
            gameObject.SetActive(true);
            ANDGateGameObject.SetActive(false);
            Debug.Log("lamp1 UIT");
            door.DoorSignalClose1();
        }
    }

    // Implement these methods to satisfy the Ilamp interface
    public void leverOnSignal4() { }
    public void leverOffSignal4() { }
}
