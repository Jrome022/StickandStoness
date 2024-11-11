using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player;
    public float smoothNess = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(player.position.x, player.position.y, 0f);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothNess * Time.deltaTime);

    }
}
