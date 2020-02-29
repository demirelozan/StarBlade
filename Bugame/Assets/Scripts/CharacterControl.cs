using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterControl : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    LayerMask groundLayer;

    private CircleCollider2D circleCollider;

    private Animator animator;

    [SerializeField]
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(circleCollider.bounds.center, Vector2.down, circleCollider.bounds.extents.y + 0.1f, groundLayer);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;

        }
        else
        {
            rayColor = Color.red;

        }
        Debug.DrawRay(circleCollider.bounds.center, Vector2.down, rayColor);

        return raycastHit.collider != null;
    }


    private float horizontal;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        circleCollider = GetComponent<CircleCollider2D>();

        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Debug.Log(animator.GetBool("isJumping"));
        Animations();
    }


    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        rb.velocity = new Vector2(horizontal * 3, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.W) && isGrounded())
        {
            animator.SetBool("isJumping", true);
            rb.AddForce(new Vector2(0, 150));
            
        }
        else if(isGrounded() == false)
        {
            animator.SetBool("isJumping", false);

        }

    }
    private void Animations()
    {
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(5,5, 5);
        }
        if (horizontal < 0)
        {
            transform.localScale = new Vector3(-5, 5, 5);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
}
