
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;


    private void Update()
     {
         transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z),
         ref velocity, speed * Time.deltaTime);
    }
    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
    //  public Transform player;
    //  public float smoothNess = 2f;

    //  void Update()
    //  {

    //    Vector3 targetPos = new Vector3(player.position.x, player.position.y, transform.position.z);
    //    transform.position = Vector3.Lerp(transform.position, targetPos, smoothNess * Time.deltaTime);

    //  }

    //  public void MoveToNewRoom(Transform _newRoom)
    //  {
    //     player.position.x = _newRoom.position.x;
    //  }
}
