//ENEMY - applied to enemies 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

// int speed
// int strength
// float closeToPlayer
// EnemyData data
// GameObject player
// Animator animator
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private int damage;
    [SerializeField] private float range;
    public float chaseRadius;
    public float attackRadius;
    [SerializeField] private EnemyData data;
    public Transform player;
    public Animator animator;
    private Vector3 direction;
    private bool isMoving = false;
    private bool attacking = false;
    private float timer = 0f;
    private float AttackLength = 2.5f;



// Start
    // find player 
    // call SetEnemyValues 
void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        SetEnemyValues();
    }

// Update 
    //call swarm 
void Update()
    {
        Swarm();

        if(attacking == true)
            {
                timer += Time.deltaTime;

                if(timer >= AttackLength)
                {
                    timer = 0f;
                    attacking = false;
                }
            }
    }


public void SetEnemyValues()
    {
        GetComponent<Health2>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
        chaseRadius = data.chaseRange;
        attackRadius = data.attackRange;
        range = data.range;
    }

// swarm 
    // check distance between player and enemy
    // figure out direction 
    // if distance <= closeToPlayer:
        // move towards player 
        // set moving to true
    // if distance > closeTo Player 
        // stop moving
        // ste moving false
    
    //call Animator(direction)

private void Swarm()
{
    if(Vector3.Distance(player.position, transform.position) <= chaseRadius 
        && Vector3.Distance(player.position, transform.position) > range)
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        isMoving = true;
    }
    else
    {
        isMoving = false;
    }

    if(Vector3.Distance(player.position, transform.position) <= attackRadius && timer == 0f)
    {
        Attack();
    }
    Animation(direction);

}

private void Attack()
{
    attacking = true;
    if (player.GetComponent<Health2>() != null)
            {
                Health2 health = player.GetComponent<Health2>();
                health.Damage(damage);
            }
}



// Animator(direction)
    // if moving
        // set isMoving true
        // set horizontal and veritcal to direction
        // flip depending on direction x++ = right x-- = left
    //else
        //set isMoving alse

void Animation(Vector3 direction)
{
    if (animator!= null)
        {
            if( isMoving == true)
            {
                animator.SetBool("isMoving", true);
                
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

            if( attacking == true)
            {
                animator.SetBool("isAttacking", true);
                
            }
            else
            {
                animator.SetBool("isAttacking", false);
            }
        }
}

}