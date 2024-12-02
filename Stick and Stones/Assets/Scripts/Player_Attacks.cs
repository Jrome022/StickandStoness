using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attacks : MonoBehaviour
{
	public Animator anim;

    // Start is called before the first frame update
    void Attack()
    {
            }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)){
		anim.SetBool("attacks", true);
	}

    }
}
