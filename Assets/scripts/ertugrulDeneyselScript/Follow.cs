using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer2D : MonoBehaviour
{

    
    public Transform playerTransform;

    public Transform player2Transform;

    public Transform player3Transform;
    
    public Vector2 offset;
    public Camera mainCam;

    float nextLevelLoad = 5.6f;
    float cameraLocIncrease = 5.3f;
    

    private void Awake() {
        //playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        //player2Transform = GameObject.Find("PlayerForLevel2").GetComponent<Transform>();
        //player3Transform = GameObject.Find("PlayerForLevel3").GetComponent<Transform>();
    }
    
    
    private void Start()
    {
        mainCam = GetComponent<Camera>();
    }




    private void FixedUpdate()
    {
        //if (playerTransform.position.y > nextLevelLoad )
        //{
        //    mainCam.GetComponent<Camera>().transform.position = new Vector3(transform.position.x, transform.position.y + cameraLocIncrease*2, -10);
        //    nextLevelLoad += cameraLocIncrease*2;
        //}
        



        if (mainCam.GetComponent<Camera>().transform.position.y < playerTransform.position.y)
        {
            mainCam.GetComponent<Camera>().transform.position = new Vector3(transform.position.x,playerTransform.position.y, -10);
        }

    }
}
