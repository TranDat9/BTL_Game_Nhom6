using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public static bool CheckPause = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {

        if(CheckPause == false)
        {
            Time.timeScale = 0f;
            CheckPause = true;
        }
        else if(CheckPause == true)
        {
            Time.timeScale = 1f;
            CheckPause = false;

        }
    }
}
