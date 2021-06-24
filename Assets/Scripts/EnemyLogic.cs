using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public float speed = 2f;

    private Rigidbody2D body;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(speed,body.velocity.y);//this is to move the enemies towards a particular direction 

    }
}
