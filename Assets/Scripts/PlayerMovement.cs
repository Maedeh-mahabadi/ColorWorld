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

        // Flip the character based on movement direction
        if (Move > 0) // Moving right
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (Move < 0) // Moving left
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }


        if(Input.GetButtonDown("Jump") && isJumping==false)
        {
            rb.AddForce(new Vector2(rb.velocity.x,Jump));
            Debug.Log("jump");
        }
    }

     private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag=="Ground"|| other.gameObject.tag == "WaterGround")
        {
            isJumping=false;
            Debug.Log("on the Ground");
        }
    }

        private void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.tag=="Ground"|| other.gameObject.tag == "WaterGround"){
            isJumping=true;
            Debug.Log("on the fly");
        }
    }
}



