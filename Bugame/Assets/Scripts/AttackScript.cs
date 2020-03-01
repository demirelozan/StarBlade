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

    public KeyCode Attack;


    private Animator anim;

    private int temp;

    
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        AttackOnEnemy();
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
        if (this.gameObject.GetComponent<CharacterControl>().horizontal > 0 || this.gameObject.GetComponent<CharacterControl>().horizontal < 0)
        {


            if (swState == swordState.top)
            {
                anim.SetBool("midWalk", false);
                anim.SetBool("lowWalk", false);
                anim.SetBool("highWalk", true);
                if (Input.GetKeyDown(Attack))
                {
                    anim.SetTrigger("highAttack");
                }
                
            }
            if (swState == swordState.middle)
            {
                anim.SetBool("lowWalk", false);
                anim.SetBool("highWalk", false);
                anim.SetBool("midWalk", true);
                if (Input.GetKeyDown(Attack))
                {
                    anim.SetTrigger("middleAttack");
                }
                
            }
            if (swState == swordState.bottom)
            {
                anim.SetBool("highWalk", false);
                anim.SetBool("midWalk", false);
                anim.SetBool("lowWalk", true);
                if (Input.GetKeyDown(Attack))
                {
                    anim.SetTrigger("lowAttack");
                }
                
            }
        }
    }
    private void AttackOnEnemy()
    {
        //attack tuşuna basıldığında playerdan aşağı yukarı orta olacak şekilde 3 raycast yolla biri çalışsın sadece. raycast enemy e değiyosa ölsün 
    }
}
