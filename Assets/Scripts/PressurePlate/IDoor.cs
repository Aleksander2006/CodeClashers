using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface waar andere bestanden de onderstaande functies vanuit kunnen lezen
public interface IDoor {

    void OpenDoor();

    void CloseDoor();
    
    void DoorSignal1();

    void DoorSignal2();

    void DoorSignal3();

    void DoorSignalClose1();

    void DoorSignalClose2();
}