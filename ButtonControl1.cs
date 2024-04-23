using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonControl1 : MonoBehaviour
{
    private string level1 = "Cave1";
    //public ResetValues resetValues;

    public void RestartGame()
    {
        //resetValues.Reset();
        SceneManager.LoadScene(level1);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
