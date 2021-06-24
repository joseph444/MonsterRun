using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    private string PLAYER_TAG = "Player";

    private Transform player;
    private Vector3 cameraPos;

    public float minX,maxX;

    private void Awake() {
        
    }
    void Start()
    {
        //Debug.Log(GameManager.instance.CharIndex);
        player = GameObject.FindWithTag(PLAYER_TAG).transform;
    }

    // Update is called once per frame
    void Update()
    {
        // cameraPos = transform.position;
        // cameraPos.x = player.position.x;

        // transform.postition = cameraPos;

        //we generally  don't call this transformation in update at it may cause glitching what we do is we call it in
        //LateUpdate method
    }

    void LateUpdate()
    {
        if(!player)
            return;
        cameraPos = transform.position;
        cameraPos.x = player.position.x;
        float MyPostion = transform.position.x;

        if(cameraPos.x>minX && cameraPos.x<maxX){
            transform.position = cameraPos;
        }
        
    }
}
