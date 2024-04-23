 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableObjects : MonoBehaviour
{
    private int health;
    [SerializeField] private ObjectData data;
    public FloatSO Score;
    public ScoreManager scoreManager;


    void Start()
    {
        SetObjectValues();
    }

    private void SetObjectValues()
    {
        health = data.hp;
    }

    public void Damage(int amount)
    {  
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }
        
        this.health -= amount;
        
        if(health <= 0)
        {
            Break();
        }
    }

    private void Break()
    {
        if(this.tag == "Crate"){
            Score.Value += 50;
            scoreManager.UpdateScore();
        }
        if(this.tag == "Barrel"){
            Score.Value += 75;
            scoreManager.UpdateScore();
        }
        Destroy(gameObject);
        
    }




}
