// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Arrow : MonoBehaviour
// {
//     private PlayerAttack weapons;

//     private float speed = 6f;

//     private Enemy enemy;

//     private bool facingRight;

//     private bool moveLeft = false, moveRight = false;

//     // Start is called before the first frame update
//     void Start()
//     {
//         weapons = GameObject.Find("Player").GetComponent<PlayerAttack>();

//         transform.eulerAngles = new Vector3(0,0,-45);

        

//         if (facingRight){
//             moveRight = true;
//             moveLeft = false;
//         }
//         else if (!facingRight){
//             moveLeft = true;
//             moveRigt = false;
//         }

//         Debug.Log("Player is facing: " + facingRight);

//     }

//     // Update is called once per frame
//     void Update()
//     {
//         facingRight = weapons.facingRight;
        
//         if (moveRight){
//             // transform.position += new Vector2(Vector2.right * speed * Time.deltaTime, 0);
//             transform.position += Vector3.right * speed * Time.deltaTime;
//         }
//         else if (moveLeft){
//             // transform.position += new Vector2(Vector2.left * speed * Time.deltaTime, 0);
//             transform.position += Vector3.right * speed * Time.deltaTime;
//             transform.localScale = new Vector3(-2,-2,-2);
//         }
//     }

//     private void OnTriggerEnter2D(Collider2D other) {
//         if (other.gameObject.tag == "Enemy"){
//             enemy = other.GetComponent<Enemy>();
//             enemy.DamageTaken(weapons.damage);
//         }
//         else if (other.gameObject.tag == "Ground"){
//             Destroy(this.gameObject);
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private PlayerAttack weapons;

    private float speed = 6f;

    private Enemy enemy;

    private bool facingRight;

    private bool moveLeft = false, moveRight = false;

    // Start is called before the first frame update
    void Start()
    {
        weapons = GameObject.Find("Player").GetComponent<PlayerAttack>();

        // Initial arrow rotation (adjust as necessary)
        transform.eulerAngles = new Vector3(0, 0, -45);  // Example rotation

        // Set direction based on player's facing direction
        facingRight = weapons.facingRight;
        if (facingRight)
        {
            moveRight = true;
            moveLeft = false;
        }
        else
        {
            moveLeft = true;
            moveRight = false;
        }

        Debug.Log("Player is facing: " + facingRight);
    }

    // Update is called once per frame
    void Update()
    {
        // In case you want to update facing direction dynamically, but already set in Start
        facingRight = weapons.facingRight;

        if (moveRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if (moveLeft)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.DamageTaken(weapons.damage);
                Destroy(this.gameObject);  // Destroy the arrow when it hits an enemy
            }
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);  // Destroy the arrow when it hits the ground
        }
    }
}
