using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiComponents : MonoBehaviour
{
   
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Home(){
        SceneManager.LoadScene("MainMenu");
    }
}
