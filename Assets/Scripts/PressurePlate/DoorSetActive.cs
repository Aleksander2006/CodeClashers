using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorSetActive : MonoBehaviour, IDoor
{
    private bool isDoorOpen = false;
    public bool isDoorOpen1 = false;
    public bool isDoorOpen2 = false;
    public bool isDoorOpen4 = false;
  
    [SerializeField] private Animator DoorOpen;

    public void Start()
    {
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

    //Show de closed door
    public void CloseDoor()
    {
        isDoorOpen = false;
        DoorOpen.SetBool("AnimPlayer", false);
    }

    //AND levers signaal voor de deur
    public void DoorSignal1()
    {
        isDoorOpen1 = true;
        isDoorOpen = isDoorOpen1 && isDoorOpen2 && isDoorOpen4;
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

    public void DoorSignal4()
    {
        isDoorOpen4 = true;
        gameObject.SetActive(true);
        Debug.Log("door4 TRUE");
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
    public void DoorSignalClose4()
    {
        isDoorOpen4 = false;
        isDoorOpen = false;
    }

   //Checkt of de signalen van bijde lampjes aan zijn, opent dan de deur
    public void DoorSignal3()
    {
        if (isDoorOpen1 && isDoorOpen2 && isDoorOpen4)
        {
            if (!isDoorOpen)
            {
                OpenDoor();
                DoorOpen.SetBool("AnimPlayer", true);
            }
        }
    }

    
}