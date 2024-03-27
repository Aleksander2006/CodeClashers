using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDoor
{
    void OpenDoor();
    void CloseDoor();
    
    void DoorSignal1();
    void DoorSignal2();
    void DoorSignal3();
    void DoorSignalClose1();

    void DoorSignalClose2();
    
}