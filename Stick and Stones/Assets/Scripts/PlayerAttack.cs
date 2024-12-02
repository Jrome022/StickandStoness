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
    public float startTimBtwAttack = 0.5f;
    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public int damage;

    public float attackRangeX;
    public float attackRangeY;
    
    private PlayerWeapons weapons;

    public Animator attackAnim;

    public int health;

    [SerializeField] private GameObject arrow, stone;

    public bool facingRight = true;

    void Start()
    {
        attackAnim = GetComponent<Animator>();

        weapons = GetComponent<PlayerWeapons>();
    }

    // Update is called once per frame
    void Update(){
        // Check if player is facing the correct direction for projectiles
        if (Input.GetKey(KeyCode.D)) {
            facingRight = true;
        }
        else if (Input.GetKey(KeyCode.A)) {
            facingRight = false;
        }

        // Player attacking
        if (timeBtwAttack <= 0)
        {
            // Left weapon attack
            if (Input.GetKey(KeyCode.Mouse0))
            {
                // No animator yet, so skipping animation
                if (weapons.leftWeaponNum != 0 && weapons.leftWeaponNum != 6)
                {
                    Debug.Log("Left pressed");
                    // Set weapon stats based on the weapon number
                    SetWeaponStats(weapons.leftWeaponNum);
                }

                if (weapons.leftWeaponNum < 9 && weapons.leftWeaponNum > -1 && weapons.leftWeaponNum != 0 && weapons.leftWeaponNum != 6)
                {
                    AttackMelee();
                }
                else if (weapons.leftWeaponNum == 0 || weapons.leftWeaponNum == 6)
                {
                    // Spawn projectiles
                    Vector3 spawnPosition = transform.position + new Vector3(facingRight ? 1f : -1f, 1f, 0);

                    if (weapons.leftWeaponNum == 0 && weapons.arrowCount > 0)
                    {
                        Instantiate(arrow, spawnPosition, Quaternion.identity);
                        Debug.Log("Arrow Released");
                        weapons.arrowCount--;
                    }
                    else if (weapons.leftWeaponNum == 6 && weapons.stoneCount > 0)
                    {
                        Instantiate(stone, spawnPosition, Quaternion.identity);
                        weapons.stoneCount--;
                        Debug.Log("Stone Released");
                    }

                    // Reset the attack cooldown
                    timeBtwAttack = startTimBtwAttack;
                }
            }

            // Right weapon attack
            if (Input.GetKey(KeyCode.Mouse1))
            {
                // Right weapon stats
                if (weapons.rightWeaponNum != 0 && weapons.rightWeaponNum != 6)
                {
                    Debug.Log("Right pressed");
                    SetWeaponStats(weapons.rightWeaponNum);
                }

                if (weapons.rightWeaponNum < 9 && weapons.rightWeaponNum > -1 && weapons.rightWeaponNum != 0 && weapons.rightWeaponNum != 6)
                {
                    AttackMelee();
                }
                else if (weapons.rightWeaponNum == 0 || weapons.rightWeaponNum == 6)
                {
                    Vector3 spawnPosition = transform.position + new Vector3(facingRight ? 1f : -1f, 1f, 0);

                    if (weapons.rightWeaponNum == 0 && weapons.arrowCount > 0)
                    {
                        Instantiate(arrow, spawnPosition, Quaternion.identity);
                        weapons.arrowCount--;
                        Debug.Log("Arrow Released");
                    }
                    else if (weapons.rightWeaponNum == 6 && weapons.stoneCount > 0)
                    {
                        Instantiate(stone, spawnPosition, Quaternion.identity);
                        weapons.stoneCount--;
                        Debug.Log("Stone Released");
                    }
                }
            }

            // Reset the cooldown at the end of the attack cycle
            timeBtwAttack = startTimBtwAttack;
        }
        else
        {
            // Reduce the cooldown timer
            timeBtwAttack -= Time.deltaTime;
        }
    }


    private void AttackMelee(){
        Collider2D[] enemiesInRange = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0,  whatIsEnemy); 

        for (int i=0; i<enemiesInRange.Length; i++){
            enemiesInRange[i].GetComponent<Enemy>().DamageTaken(damage);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }

    public void DamageTaken(int damage){

    }

    void SetWeaponStats(int weaponNum){
        switch (weaponNum){
            case 0:  // Bow
                damage = 5;
                timeBtwAttack = 1.5f;
                break;
            case 1:  // Club
                damage = 3;
                timeBtwAttack = 1f;
                break;
            case 2:  // Dual
                damage = 8;
                timeBtwAttack = 1f;
                break;
            case 3:  // Knife
                damage = 4;
                timeBtwAttack = 0.5f;
                break;
            case 4:  // Scimitar
                damage = 10;
                timeBtwAttack = 1.5f;
                break;
            case 5:  // Shield
                damage = 2;
                timeBtwAttack = 1f;
                break;
            case 6:  // Sling
                damage = 4;
                timeBtwAttack = 1.2f;
                break;
            case 7:  // Spear
                damage = 8;
                timeBtwAttack = 1f;
                break;
            case 8:  // Sword
                damage = 6;
                timeBtwAttack = 0.8f;
                break;
            default:
                break;
        }
    }
}
