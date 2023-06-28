using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float speed;
    public float jump;
    private float Move;
    private bool isGrounded;
    private Rigidbody2D rb;
    private Animator anim;
void Start()
{
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
}

     void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("ground")){
            isGrounded = true;
        }else{
            isGrounded = false;
        }
    }

void Update()
{
    Move = Input.GetAxis("Horizontal");
    rb.velocity = new Vector2(Move * speed ,rb.velocity.y);
    if(Move != 0 && isGrounded==true){
        anim.SetBool("isWalking",true);
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