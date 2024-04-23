using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetValues : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private FloatSO healthSO;
    [SerializeField] private FloatSO Score;
    public ScoreManager scoreManager;
        
    void Start()
    {
       Reset();
    }
    public void Reset()
    {
        Score.Value = 0;
        healthSO.Value = 100;
        scoreManager.UpdateScore();
    }
}
