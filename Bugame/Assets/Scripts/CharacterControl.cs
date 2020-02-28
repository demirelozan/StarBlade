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

    [SerializeField]
    private bool isGrounded()
    {   
        RaycastHit2D raycastHit = Physics2D.Raycast(circleCollider.bounds.center, Vector2.down,circleCollider.bounds.extents.y + 0.1f,groundLayer);
        Color rayColor;
        if(raycastHit.collider != null)
        {
            rayColor = Color.green;    

        }
        else
        {
            rayColor = Color.red;

        }
        Debug.DrawRay(circleCollider.bounds.center, Vector2.down, rayColor);

        return raycastHit.collider!= null;
    }


    private float horizontal;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        circleCollider = GetComponent<CircleCollider2D>();
    }

    
    
    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.W) && isGrounded())
        {
            rb.AddForce(new Vector2(0, 150));
        }

    }
}
