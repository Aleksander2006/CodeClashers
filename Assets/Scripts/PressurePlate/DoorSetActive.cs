using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorSetActive : MonoBehaviour, IDoor
{

    private bool isDoorOpen = false;
    public bool isDoorOpen1 = false;
    public bool isDoorOpen2 = false;
    public bool isDoorOpen3 = false;                                                    //!nieuw
    [SerializeField] private Animator DoorOpen;

    public void Start() {
        DoorOpen.SetBool("AnimPlayer", false);
    }

    public void Update()
    {
        DoorSignal3();
    }

    //Hide de closed door
    public void OpenDoor()
    {
        isDoorOpen = true;
    }

    //Showd de closed door
    public void CloseDoor()
    {
        isDoorOpen = false;
        DoorOpen.SetBool("AnimPlayer", false);
    }

    //AND levers signaal voor de deur
    public void DoorSignal1()
    {
        isDoorOpen1 = true;
        gameObject.SetActive(true);
        Debug.Log("door1 TRUE");
    }

    //PressurePlate signaal voor de deur
    public void DoorSignal2()
    {
        isDoorOpen2 = true;
        gameObject.SetActive(true);
        Debug.Log("door2 TRUE");
    }

    public void DoorSignal4() {
        isDoorOpen3 = true;
    }

    public void DoorSignalClose3() {
        isDoorOpen3 = false;
    }

    //Reset de values van signalen van AND lampje
    public void DoorSignalClose1()
    {
        isDoorOpen1 = false;
        isDoorOpen = false;
    }

    //Reset de values van signalen van PressurePlate lampje
    public void DoorSignalClose2()
    {
        isDoorOpen2 = false;
        isDoorOpen = false;
    }

    //Checkt of de signalen van bijde lampjes aan zijn, opent dan de deur
    public void DoorSignal3()
    {
        if (isDoorOpen1 && isDoorOpen2 && isDoorOpen3)
        {
            if (!isDoorOpen)
            {
                OpenDoor();
                DoorOpen.SetBool("AnimPlayer", true);
            }
        }
    }
}