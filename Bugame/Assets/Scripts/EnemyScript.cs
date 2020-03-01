using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Transform player;
    private Animator anim;
    private float playerHealth = 120;
    UnityEngine.AI.NavMeshAgent nav;
    public bool allowtohit = false;
    private float navspeed = 0.5f;

    private bool enemyDeath = false;

    private void Awake()
    {
        if (!enemyDeath)
        {
            nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
            anim = GetComponent<Animator>();


            
        }
    }
    private void OnGUI()
    {
        nav.SetDestination(player.position);
        float distance = Vector3.Distance(player.transform.position, this.transform.position);
        navspeed += Time.deltaTime / 50; //değiştir
        nav.speed = navspeed;

        anim.SetBool("walk", true);
        

    }
    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
