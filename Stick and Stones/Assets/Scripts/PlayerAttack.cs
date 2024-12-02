using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // public float speed;
    // private Animator anim;
    
    // public GameObject attackPoint;
    // public float radius;
    // public LayerMask enemies;
    // Start is called before the first frame update

    private float timeBtwAttack;
    public float startTimBtwAttack;
    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public int damage;

    public float attackRangeX;
    public float attackRangeY;
    
    private PlayerWeapons weapons;
    private int leftWeaponNum, rightWeaponNum;

    public Animator attackAnim;

    public int health;

    void Start()
    {
        attackAnim = GetComponent<Animator>();

        weapons = GetComponent<PlayerWeapons>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        //   {
             
        //      anim.SetBool("Attack", true);
        //   }

        //check if player can attack
        if (timeBtwAttack <= 0){
            if (Input.GetKey(KeyCode.Mouse0)){
                // attackAnim.SetBool("Attack", true); no animator yet
                switch (leftWeaponNum){
                    case 0:
                        damage = 3;
                        timeBtwAttack = 0.2f;
                        break;
                }
                Debug.Log("Space pressed");
                Collider2D[] enemiesInRange = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0,  whatIsEnemy); 

                for (int i=0; i<enemiesInRange.Length; i++){
                    enemiesInRange[i].GetComponent<Enemy>().DamageTaken(damage);
                }
            }

            timeBtwAttack = startTimBtwAttack;
        }
        else {
            timeBtwAttack -= Time.deltaTime; 
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }

    // public void attack()
    // {
    //     Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

    //     foreach (Collider2D enemyGameobject in enemy)
    //     {
    //         Debug.Log("Hit Enemy");
    //     }
    // }

    // public void endAttack()
    // {
    //     anim.SetBool("Attack", false);
    // }

    // private void OnDrawGizmos()
    // {
    //      Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    // }
}
