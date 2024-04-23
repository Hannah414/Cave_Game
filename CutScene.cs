using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CutScene : MonoBehaviour
{
    int num = 0;
    public Text messageText;

    void Start()
    {
        ChangeMessage();
    }

    // Update is called once per frame
    void Update()
    {
        //if player hits enter
            //call ChangeMessage Function

        if(Input.GetKeyDown(KeyCode.Return))
            {
                ChangeMessage();
            }

    }

    //ChangeMessage 
        //num +=1;
        //if num = 0
            //messageText = "Message 0"
        //if num = 1
            //messageText = "Message 1"
        //if num = 2
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    public void ChangeMessage()
    {
        if(num == 0)
            {
            messageText.text = "Message 0";
            }
        if(num == 1)
            {
            messageText.text = "Message 1";
            }
        if(num == 2)
            {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
            }

        num += 1;
    }
}
