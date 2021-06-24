using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThePlayer : MonoBehaviour
{
   

    public float moveForce = 5f;
    public float jumpForce = 30f;



    public float movement ;

    private Rigidbody2D playerBody;

    private Animator animator;

    private string WALK_ANIMATION = "walk",GROUND_TAG="Ground";

    private string ENEMY_TAG="Enemy";
    private string JUMP_ANIMATION = "jump";

    private SpriteRenderer sprite;

    private bool isGrounded;

    private void Awake() {
        this.playerBody = GetComponent<Rigidbody2D>();
        this.animator   = GetComponent<Animator>();
        this.sprite     = GetComponent<SpriteRenderer>();
    }

    void Start()
    {   
        this.playerBody.AddForce(new Vector2(2,2));
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        AnimatePlayer();
        ChangeDirection();
        PlayerJump();
        
    }

    void FixedUpdate()
    {
        //we use this method when a particular operation needs to perform some physics calculation.(Mainly in rigibody) 
       
    }

    void PlayerMovement(){
        this.movement = Input.GetAxisRaw("Horizontal"); //Basically on right arrow key press it gives 1 and for left arrow key it gives negetive one.
        transform.position += new Vector3(this.movement,0f,0f)*Time.deltaTime * this.moveForce;
    }


    void AnimatePlayer(){
        if(this.movement!=0){
            this.animator.SetBool(this.WALK_ANIMATION,true);
        }else{
            this.animator.SetBool(this.WALK_ANIMATION,false);
        }
        
    }

    void ChangeDirection(){
        if(this.movement>0){
            this.sprite.flipX = false;
        }else if(this.movement<0){
            this.sprite.flipX = true;
        }
    }

    void PlayerJump(){
        if(Input.GetButtonDown("Jump") && isGrounded){
            this.animator.SetBool(JUMP_ANIMATION,true);
            isGrounded=false;
            //The get button down returns true only when we press the jump button assigned by unity.
            this.playerBody.AddForce(new Vector2(0f,this.jumpForce),ForceMode2D.Impulse);
            //We are adding a 2d force on yaxis. and the 2d force type is Impulse
            //Impulse is an instant force which helps in some instant shift of position or creating craters.
            // best example when some one pushes you they create and impulse on your body using their mass. That force that you feel is impulse.
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag(GROUND_TAG)){
            this.animator.SetBool(JUMP_ANIMATION,false);
            //this will check if there is an collision between the current game object and the collision with the object(s) with tag.
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG)){
            Destroy(gameObject);
            
        }
    }

    private void OnDestroy() {
        SceneManager.LoadScene("GameOver");
    }

    
}
