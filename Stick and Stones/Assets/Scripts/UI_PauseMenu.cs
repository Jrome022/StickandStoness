using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private bool isPaused;

    [SerializeField] private GameObject menu;

    public GameObject replaceMenu;

    [SerializeField] private Menu pause;

    // public int arrowCount, stoneCount;

    [SerializeField] private Button replaceBtn, weap1Btn, weap2Btn;

    private PlayerWeapons player;

    private int selected;

    [SerializeField] private GameObject invObj;
    private Inventory inv;

    
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        menu.SetActive(false);
        replaceMenu.SetActive(false);

        player = GameObject.Find("Player").GetComponent<PlayerWeapons>();

        inv = invObj.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused){
            PauseGame();
            inv.SetSprites(player.leftWeaponNum, player.rightWeaponNum);
            inv.UpdateAmmoCount(player.arrowCount, player.stoneCount);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused){
            UnpauseGame();
        }


    }

    //replace menu
    public void ShowReplaceMenu(){
        replaceMenu.SetActive(true);
    }

    public void HideReplaceMenu(){
        replaceMenu.SetActive(false);
    }

    public void SelectWeap1(){
        selected = player.leftWeaponNum;
        Debug.Log("1 selected");
    }

    public void SelectWeap2(){
        selected = player.rightWeaponNum;
        Debug.Log("2 selected");
    }

    public void ReplaceWeapon(){
        if (selected == player.leftWeaponNum){
            player.weapons[player.leftWeaponNum].SetActive(false);
            player.DropWeapon(player.leftWeaponNum);
            player.leftWeaponNum = player.weaponNum;
            player.ReplaceWeapon();
            HideReplaceMenu();
        }
        else if (selected == player.rightWeaponNum){
            player.weapons[player.rightWeaponNum].SetActive(false);
            player.DropWeapon(player.rightWeaponNum);
            player.rightWeaponNum = player.weaponNum;
            player.ReplaceWeapon();
            HideReplaceMenu();
        }
    }

    //pause and inventory menu
    public void PauseGame(){
        menu.SetActive(true);
        isPaused = true;
    }

    public void UnpauseGame(){
        menu.SetActive(false);
        isPaused = false;
    }

    //main menu
    public void RestartLevel(){
        SceneManager.LoadScene(1);
    }

    public void QuitLevel(){
        SceneManager.LoadScene(0);
    }
}
