using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponPickUp : MonoBehaviour
{
    // public Text indicator;
    public float pickUpRange = 3f;

    private PlayerWeapons player;
    [SerializeField] private TextMeshProUGUI indicator;

    public int weaponNumber;

    private bool canPickUp = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerWeapons>();

        indicator.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //checks if object can be pickedup, calls method from player script
        if (canPickUp && Input.GetKeyDown(KeyCode.E)){
            if (player.maxWeapons != 0){
                player.PickUpWeapon(weaponNumber);
                player.maxWeapons--;

                if (player.leftWeaponNum == -1){
                    player.leftWeaponNum = weaponNumber;
                }
                else if (player.rightWeaponNum == -1){
                    player.rightWeaponNum = weaponNumber;
                }

                Debug.Log("Weapon Num: " + player.weaponNum);

                Destroy(this.gameObject);
            }
            else if (player.maxWeapons != -1){
                player.maxWeapons--;
            }
             
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player"){
            indicator.enabled = true;

            if (player.maxWeapons != -1){
                canPickUp = true;
            }
            

            // if(Input.GetKeyDown(KeyCode.E)){
            //     Destroy(this.gameObject);
            // }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player"){
            indicator.enabled = false;
            canPickUp = false;
        }
    }
}
