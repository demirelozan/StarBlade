using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterControl : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField] private float jumpForce = 250;
    private BoxCollider2D boxCollider2D;
    private Animator animator;
    private AttackScript atkScr;

    public KeyCode Jump;


    [SerializeField]
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + 0.1f, groundLayer);
        Color rayColor;
        bool __state = (raycastHit.collider != null);
        rayColor = (__state) ? Color.green : Color.red;
        Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down, rayColor);
        return __state;
    }


    public float horizontal;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        atkScr = GetComponent<AttackScript>();
        
    }
    private void Update()
    {
        //Debug.Log(animator.GetBool("isJumping"));
        Animations();
        Debug.Log(horizontal);
    }
    private void FixedUpdate()
    {
        Movement();
    }
    private void Movement()
    {
        horizontal = 0f;
        if(Input.GetKey(atkScr.moveLeft) || Input.GetKey(atkScr.moveRight))
            horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        rb.velocity = new Vector2(horizontal * 3, rb.velocity.y);
        if (Input.GetKeyDown(Jump) && isGrounded())
        {
            animator.SetBool("isJumping", true);
            rb.AddForce(new Vector2(0, jumpForce));
            
        }
        else if(isGrounded() == false)
        {
            animator.SetBool("isJumping", false);
        }
    }
    private void Animations()
    {
        if(horizontal == 0)
        {
            animator.SetBool("lowWalk", false);
            animator.SetBool("midWalk", false);
            animator.SetBool("highWalk", false);

        }
        
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(5, 5, 5);
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
