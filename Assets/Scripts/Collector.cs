using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    // Start is called before the first frame update

    private string ENEMY_TAG = "Enemy",PLAYER_TAG = "Player";
    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag(ENEMY_TAG)|| collider.CompareTag(PLAYER_TAG)){
            Destroy(collider.gameObject);
        }
    }
}
