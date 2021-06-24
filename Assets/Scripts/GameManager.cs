using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;

    public GameObject[] characters;

    private int _charIndex;
    public int CharIndex{
        get{
            return _charIndex;
        }
        set{
            _charIndex  = value;
        }
    }

    private void Awake() {
        if(instance==null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnLeveledFinishedLoading;
    }
    private void OnDisable() {
        SceneManager.sceneLoaded -= OnLeveledFinishedLoading;
    }
    void OnLeveledFinishedLoading(Scene scene,LoadSceneMode mode){
        if (scene.name == "GamePlay"){
            Instantiate(characters[_charIndex]);
        }
    }
}
