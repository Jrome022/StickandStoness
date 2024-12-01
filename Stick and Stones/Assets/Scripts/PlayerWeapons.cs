using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;

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


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        indicator.enabled = false;

        pause = GameObject.Find("UI").GetComponent<Menu>();

        replace = replaceObj.GetComponent<UI_ReplaceWeapon>();

        leftWeaponNum = -1; rightWeaponNum = -1;
    }

    // Update is called once per frame
    void Update()
    {

        //constantly checks if object can be picked up
        if (canPickUpWeapon && Input.GetKeyDown(KeyCode.E) && maxWeapons != 0){
                // PickUpWeapon(weaponNum);
                
                // if (leftWeaponNum == -1){
                //     leftWeaponNum = weaponNum;
                // }
                // else if (rightWeaponNum == -1){
                //     rightWeaponNum = weaponNum;
                // }


                
        }
        else if (maxWeapons == -1){
            pause.ShowReplaceMenu();
            menuUp = true;
            replace.SetSprites();
        }
                
        if (Input.GetKeyDown(KeyCode.E) && menuUp){
            HideMenu();
            menuUp = false;
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
        }

        else if (other.gameObject.tag == "Arrow"){
            pause.arrowCount++;
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "Stone"){
            pause.stoneCount++;
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        //if exitted trigger is "weapon" disable the indicator disables picking up weapon and weapon number becomes unusable
        if (other.gameObject.tag == "Weapon"){
            DisableIndicator();
            canPickUpWeapon = false;
            // weaponNum = -1;
        }
    }

}
