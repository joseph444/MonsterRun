using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame(){
        string checkedObj = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(checkedObj);

        GameManager.instance.CharIndex = int.Parse(checkedObj);
        SceneManager.LoadScene("GamePlay");
    }
}
