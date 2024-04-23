using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    public FloatSO Score;
    void Start()
    {
        scoreText.text = "Score: " + Score.Value.ToString();
    }

    
}
