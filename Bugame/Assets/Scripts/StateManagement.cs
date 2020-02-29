using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManagement : MonoBehaviour
{
    public enum swordState { top = 0, middle = 1, bottom = 2 };
    public GameObject p1, p2;
    void Start()
    {
        p1.GetComponent<AttackScript>().swState = swordState.middle;
        p2.GetComponent<AttackScript>().swState = swordState.middle;
    }
}
