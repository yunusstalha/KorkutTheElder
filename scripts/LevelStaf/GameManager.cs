using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{


    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (cob.instance.isDead == true)
            {
                SceneManager.LoadScene(6);
            }

            
        }
    }
}
