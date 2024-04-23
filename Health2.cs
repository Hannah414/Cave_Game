
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health2 : MonoBehaviour
{

//HEALTH

// float health
// float maxHealth

public float health;
public FloatSO healthSO;
public FloatSO Score;
public float MAX_HEALTH = 100;
public HealthBar healthBar;
public ScoreManager scoreManager;

//setHealth
    //set maxHealth
    //set current health



public void SetHealth(float maxHealth, float health)
{
    
    if(this.tag =="Enemy"){
        this.MAX_HEALTH = maxHealth;
        this.health = health;
        }
    if(this.tag =="Player")
        {this.MAX_HEALTH = maxHealth;
        this.health = healthSO.Value;
        healthBar.SetMaxHealth(health);
        }
}


// colorChanger(color)
    // set sprite.color to given color
    // wait 
    // set color back to normal 

private IEnumerator VisualIndicator(Color color)
    {
        
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
        
    }


//damage (amount)
    // if damage amout in negative
        // display error

    // set health to health -= amount 
    // call colorChanger(red)

    //if health < 0:
        // call death 

public void Damage(float amount)
    {  
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        if(this.tag == "Enemy"){
            this.health -= amount;}
        
        if(this.tag == "Player"){
            this.health = healthSO.Value;
            this.health -= amount;
            healthBar.SetHealth(health);
            healthSO.Value = health; //pinchpoint
            }
        
        StartCoroutine(VisualIndicator(Color.red));
        
        if(health <= 0)
        {
            Die();
        }
    }


//heal (amount)
    // if damage amout in negative
        // display error

    //if (health + amount) > maxHealth
        // health = maxHealth
    
    //else
        // set health to health + amount 

public void Heal(float amount)
    {   
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }
        
        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;
        
        if (wouldBeOverMaxHealth)
        {
            this.health = MAX_HEALTH;
            
            if(this.tag == "Player"){
                healthSO.Value = health;
                healthBar.SetHealth(health);}
        }
        //else add heal to health 
        else 
        {
            this.health += amount;
            if(this.tag == "Player"){
                healthSO.Value = health;
                healthBar.SetHealth(health);}
        }
    }
    

//death
    // set player.healthTrigger = false
    // destroy gameObject

private void Die()
    {   
        if(this.tag == "Enemy"){
            Score.Value += 100;
            scoreManager.UpdateScore();
        }
        if(this.tag == "Player"){
            SceneManager.LoadScene("DeathScreen");
        }

        Destroy(gameObject);
    }

} 