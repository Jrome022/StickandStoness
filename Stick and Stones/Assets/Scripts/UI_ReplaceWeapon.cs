using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ReplaceWeapon : MonoBehaviour
{
    [SerializeField] private Button replace, exit;
    [SerializeField] private Image weap1, weap2, weap3;

    [SerializeField] private Image[] weapons;

    [SerializeField] private PlayerWeapons player;

    [SerializeField] private Menu pause;

    [SerializeField] private GameObject replaceUI;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerWeapons>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSprites(){
        weap1.sprite = weapons[player.leftWeaponNum].sprite;
        weap2.sprite = weapons[player.rightWeaponNum].sprite;
        weap3.sprite = weapons[player.weaponNum].sprite;
    }

}
