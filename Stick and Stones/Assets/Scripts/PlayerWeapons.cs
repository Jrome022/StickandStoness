using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerWeapons : MonoBehaviour
{
    public GameObject[] weapons;

    private SpriteRenderer sprite;

    [SerializeField] private TextMeshProUGUI indicator;

    private bool canPickUpWeapon = false;

    public int weaponNum;

    public int maxWeapons = 2;

    public int leftWeaponNum = -1, rightWeaponNum = -1;

    [SerializeField] private Menu pause;

    [SerializeField] private GameObject replaceObj;
    private UI_ReplaceWeapon replace;

    private bool menuUp = false;

    [SerializeField] private GameObject[] weaponDrops;

    private PlayerMovement playerMove;

    private WeaponPickUp pickUp;

    public int arrowCount, stoneCount;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        indicator.enabled = false;

        pause = GameObject.Find("UI").GetComponent<Menu>();

        replace = replaceObj.GetComponent<UI_ReplaceWeapon>();

        leftWeaponNum = -1; rightWeaponNum = -1;

        playerMove = gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        //constantly checks if object can be picked up
        if (canPickUpWeapon && Input.GetKeyDown(KeyCode.E) && maxWeapons != 0){

                
        }
        else if (maxWeapons == -1 && menuUp == false){
            pause.ShowReplaceMenu();
            menuUp = true;
            replace.SetSprites();
            maxWeapons++;
            playerMove.speed = 0f;
        }
                
        if (Input.GetKeyDown(KeyCode.Q) && menuUp){
            HideMenu();
            menuUp = false;
            playerMove.speed = 5f;
        }

        
    }

    public void HideMenu(){
        pause.HideReplaceMenu();
    }

    //activates sprite of weaponNumber that is picked up
    public void PickUpWeapon(int weaponNumber){
        sprite.enabled = false;
        weapons[weaponNumber].SetActive(true);
        
    }

    public void SetWeaponNumber(int weaponNumber){
        weaponNum = weaponNumber;
    }

    //enable pickup indicator
    public void EnableIndicator(){
        indicator.enabled = true;
    }

    //disable pickup indicator
    public void DisableIndicator(){
        indicator.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D other) {
        //if object has tag "weapon" enable interact indicator enables picking up weapon
        if (other.gameObject.tag == "Weapon"){
            canPickUpWeapon = true;
            EnableIndicator();
            SetWeaponNumber(other.GetComponent<WeaponPickUp>().weaponNumber);
            pickUp = other.GetComponent<WeaponPickUp>();
	    GetComponent<Animator>().SetBool("weaponEquipped", true);
        }

        else if (other.gameObject.tag == "Arrow"){
            arrowCount++;
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "Stone"){
            stoneCount++;
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        //if exitted trigger is "weapon" disable the indicator disables picking up weapon
        if (other.gameObject.tag == "Weapon"){
            DisableIndicator();
            canPickUpWeapon = false;
        }
    }

    public void DropWeapon(int weaponNumber){
        Instantiate(weaponDrops[weaponNumber], transform.position, Quaternion.identity);
    }

    public void ReplaceWeapon(){
        PickUpWeapon(weaponNum);
        playerMove.speed = 5f;
        pickUp.DestroyPickUp();
        menuUp = false;
    }

}
