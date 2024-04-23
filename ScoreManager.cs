using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{   
    public Text scoreText;
    public FloatSO Score;
   
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = Score.Value.ToString();
    }

    // Update is called once per frame
    public void UpdateScore()
    {
        scoreText.text = Score.Value.ToString();
    }
}
