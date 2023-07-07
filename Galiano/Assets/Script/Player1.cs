using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player1 : MonoBehaviour
{
    public float speed;
    public float jump;
    private float Move;
    private bool isGrounded = false;
    private Rigidbody2D rb;
    private Animator anim;
void Start()
{
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
}

     async void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("ground")|| other.gameObject.CompareTag("Platform")){
            isGrounded = true;
        }else if(other.gameObject.CompareTag("Coin")){
            
        }else{
            isGrounded = false;
        }


        if(other.gameObject.CompareTag("Spikes")){
            SceneManager.LoadScene(2);
        }
        


    }

void Update()
{
    Move = Input.GetAxis("Horizontal");
    if(Move !=0){
        gameObject.transform.SetParent(null);
    }
    rb.velocity = new Vector2(Move * speed ,rb.velocity.y);
    if(Move != 0 && isGrounded==true){
        anim.SetBool("isWalking",true);
    }else if(Move != 0 && isGrounded==false){
        anim.SetBool("isWalking",false);
        anim.SetBool("isFlying",true);
    }else{
        anim.SetBool("isWalking",false);
    }

    


    if(isGrounded==false && rb.velocity.y > 0){
        anim.SetBool("isJumping",true);
        anim.SetBool("isFlying",false);
    }else if(isGrounded==false && rb.velocity.y < 0){
        anim.SetBool("isFlying",true);
        anim.SetBool("isJumping",false);
    }else if(isGrounded == true){
        anim.SetBool("isFlying",false);
        anim.SetBool("isJumping",false);
    }

    if((Input.GetButtonDown("Jump") || Input.GetKeyDown("[0]")) && isGrounded==true){
        rb.AddForce(new Vector2(rb.velocity.x,jump));
        isGrounded=false;
    }

    bool hasMovement = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
    if(hasMovement)
    {
        transform.localScale = new Vector2 (Mathf.Sign(rb.velocity.x), 1f); 
    }

}



}