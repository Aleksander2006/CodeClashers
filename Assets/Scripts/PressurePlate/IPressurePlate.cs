using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface waar andere bestanden de onderstaande functies van kunnen lezen
public interface IPressurePlate {
    void OpenSignal();

    void CloseSignal();

    void ToggleSignal();
}

