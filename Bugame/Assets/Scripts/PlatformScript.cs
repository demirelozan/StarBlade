using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        PlatformMove();   
    }
    private void PlatformMove()
    {
        if (button.GetComponent<ButtonScript>().IsClicked())
        {
            animator.SetBool("platformMove", true);
        }
    }
}
