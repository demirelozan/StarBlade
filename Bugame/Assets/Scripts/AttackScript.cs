using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StateManagement;

public class AttackScript : MonoBehaviour
{
    public swordState swState;
    public KeyCode upState;
    public KeyCode downState;
    public KeyCode moveLeft;
    public KeyCode moveRight;
    private Animator anim;
    private int temp;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //Increments and Decrements
        if (Input.GetKeyDown(upState))
        {
            temp = Mathf.Clamp(((int)swState) - 1, 0, 2);
            switch (temp)
            {
                case 0:
                    swState = swordState.top;
                    break;
                case 1:
                    swState = swordState.middle;
                    break;
                case 2:
                    swState = swordState.bottom;
                    break;
            }
            Debug.Log($"new swState={(int)swState}");
        }
        if (Input.GetKeyDown(downState))
        {
            temp = Mathf.Clamp(((int)swState) + 1, 0, 2);
            switch (temp)
            {
                case 0:
                    swState = swordState.top;
                    break;
                case 1:
                    swState = swordState.middle;
                    break;
                case 2:
                    swState = swordState.bottom;
                    break;
            }
            Debug.Log($"new swState={(int)swState}");
        }
        //Animations
        if (swState == swordState.top)
        {
            
        }
        if (swState == swordState.middle)
        {

        }
        if (swState == swordState.bottom)
        {

        }
    }
}
