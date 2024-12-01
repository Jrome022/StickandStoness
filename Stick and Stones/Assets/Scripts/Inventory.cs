using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Image[] weapons;

    [SerializeField] private Image weap1, weap2;

    [SerializeField] private Text arrowCount, stoneCount;

    [SerializeField] private GameObject weap1Obj, weap2Obj;

    private PlayerWeapons player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerWeapons>();

        weap1Obj.SetActive(false);

        weap2Obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSprites(int leftWeaponNum, int rightWeaponNum){
        if (leftWeaponNum != -1){
            weap1Obj.SetActive(true);
            weap1.sprite = weapons[leftWeaponNum].sprite;
        }
        
        if (rightWeaponNum != -1){
            weap2Obj.SetActive(true);
            weap2.sprite = weapons[rightWeaponNum].sprite;
        }
    }

    public void UpdateAmmoCount(int arrowCount, int stoneCount){
        this.arrowCount.text = "X " + arrowCount.ToString();
        this.stoneCount.text = "X " + stoneCount.ToString();
    }
}
