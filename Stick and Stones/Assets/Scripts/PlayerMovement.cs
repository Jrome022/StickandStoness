using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     public Rigidbody2D rb;
     public Animator anim;
     public float movement;
     public float speed = 5f;
     public float jumpHeight = 7f;
     public bool isGround = true;
     private bool facingRight = true;
     
     void Start()
     {

     }
     void Update()
     {
          movement = Input.GetAxis("Horizontal");
          transform.position += new Vector3(movement * Time.deltaTime * speed, 0f, 0f);
          Flip();
          if (Input.GetKey(KeyCode.Space) && isGround)
          {
              Jump();
              anim.SetBool("Jump", true);
              isGround = false;
          }

          if (Mathf.Abs(movement) > .1f)
          {
              anim.SetFloat("Run", 1f);
          }

          else if (movement < .1f)
          {
              anim.SetFloat("Run", 0f);
          }

          
     }

    void Jump()
    {
         Vector2 velocity = rb.velocity;
         velocity.y = jumpHeight;
         rb.velocity = velocity;
    }



    void Flip()
    {
        if(movement < 0f && facingRight)
        {
            transform.eulerAngles = new Vector3(0f, -180f, 0f);
            facingRight = false;
        }
        else if(movement > 0f && facingRight == false)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            facingRight = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGround = true;
            anim.SetBool("Jump", false);
        }
    }
}
