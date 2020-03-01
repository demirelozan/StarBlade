using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    private float speed = 0.5f;
    private float stoppingDistance = 2f;
    private float startingDistance = 25f;

    private Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        EnemyFollow();   
    }
    private void EnemyFollow()
    {
        if(Vector2.Distance(transform.position,target.position) > stoppingDistance  && Vector2.Distance(transform.position,target.position) < startingDistance)
        {
            animator.SetBool("attack", false);
            animator.SetBool("move", true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
           // animator.SetBool("walk", false);
           // animator.SetBool("attack", true);
        }
    }
}
