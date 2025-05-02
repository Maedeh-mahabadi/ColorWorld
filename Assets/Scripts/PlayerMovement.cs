using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    private float Move;
    public float Jump;
    public bool isJumping;
    private Rigidbody2D rb;
        void Start()
    {
        rb=GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Move=Input.GetAxis("Horizontal");
        rb.velocity=new Vector2(Speed*Move,rb.velocity.y);

        if(Input.GetButtonDown("Jump") && isJumping==false)
        {
            rb.AddForce(new Vector2(rb.velocity.x,Jump));
            Debug.Log("jump");
        }
    }

     private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag=="Ground"){
            isJumping=false;
            Debug.Log("on the Ground");
        }
    }

        private void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.tag=="Ground"){
            isJumping=true;
            Debug.Log("on the fly");
        }
    }
}



