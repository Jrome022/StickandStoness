using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    private bool isPaused;

    [SerializeField] private GameObject menu;

    public GameObject replaceMenu;

    [SerializeField] private TextMeshProUGUI arrow, stone;

    [SerializeField] private Menu pause;

    public int arrowCount, stoneCount;

    
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        menu.SetActive(false);
        replaceMenu.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused){
            menu.SetActive(true);
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused){
            menu.SetActive(false);
            isPaused = false;
        }

    }

    public void ShowReplaceMenu(){
        replaceMenu.SetActive(true);
    }

    public void HideReplaceMenu(){
        replaceMenu.SetActive(false);
    }
}
