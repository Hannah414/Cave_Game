//PLAYER 

// float speed
// Animator animator 
// Vecotr 3 direction 
// bool Attacking = false 
// float AttackLength
// float timer
// int sword

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player2 : MonoBehaviour
{


private GameObject attackArea = default;
public float speed;
public Animator animator;
public Vector3 direction;
private bool Attacking = false;
private float AttackLength = 0.5f;
private float timer = 0f;
public int sword = 0;
public HealthBar healthbar;
public Health2 health;
[SerializeField] private FloatSO healthSO;

void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        GetComponent<Health2>().SetHealth(100, 100);
    }

// Update Funtion 
    // checks for vertical and horizontal input 
        // sets direction to input 
        // include exception for diagonal movment
        // calls animation (direction)
    // check is sword is picked up 
        // if space is pressed 
            //call attack funtion (direction)
        // if attack = true 
            // start timer
            // if timer > attack length
                // set timer back to 0
                // set attacking to false
                // 
private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(horizontal !=0)  vertical = 0;

        direction = new Vector3 (horizontal, vertical);

        Animate(direction);

        if(sword == 1)
        {     
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Attack(direction);
            }

            if(Attacking == true)
            {
                timer += Time.deltaTime;

                if(timer >= AttackLength)
                {
                    timer = 0f;
                    Attacking = false;
                    attackArea.SetActive(Attacking);
                    //attackArea.SetActive(attacking);
                    //AttackRange2 attackRange = GetComponent<AttackRange2>();
                    //attackRange.AttackingActive = false;
                    Animate(direction);
                }

            }
        }
    }

// fixedUpdate
    // prevents stalling when input can not be comleted (ie, running into a wall) 

private void FixedUpdate(){

        transform.position += direction * speed * Time.deltaTime;
    }


// Attack
        // set attacking to true 
        // call animatior (direction)
        // apply damage to enemy
        //

private void Attack(Vector3 direction)
    {
        Attacking = true;
        Animate(direction);
        //gets here ok
        attackArea.SetActive(Attacking);

        //AttackRange2 attackRange = gameObject.GetComponent<AttackRange2>();
        //attackRange.AttackingActive = true;
        //Debug.Log("test 1 ");
    }

// Animation - takes in Vector 3 direction
    // if there is movement 
        // set isMoving to true
        // set horizontal and veritcal to direction
    // else
        // set isMoving to false 
    //if attacking = true
        // set isAttacking to true 
        // set horizontal and vertical to direction
    // else
        // set isAttcking to false

void Animate(Vector3 direction)
    {
        if (animator!= null)
        {
            if( direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat("horizontal", direction.x );
                animator.SetFloat("vertical", direction.y );
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

            if(Attacking == true)
            {   
                animator.SetBool("isAttacking", true);
                animator.SetFloat("horizontal", direction.x );
                animator.SetFloat("vertical", direction.y );
            }
            else
            {
                animator.SetBool("isAttacking", false);
            }
        }
    }


}



//if (animator.IsPlaying("IdleLeft") = true)
    //animator.Play("SliceLeft")


