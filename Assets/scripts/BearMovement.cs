using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BearMovement : MonoBehaviour
{

    private Vector2 leftBound;
    private Vector2 rightBound;
    public float speed = 0;

    public Vector2 current;
    public Vector2 before;

    public string isLeft = "r";
    public string currtentWay;




    void Start()
    {


        currtentWay = "r";


    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("collision");
        leftBound.x = collision.gameObject.transform.position.x - ((-0.068f - -0.838f) / 2);
        rightBound.x = collision.gameObject.transform.position.x + ((-0.068f - -0.838f) / 2);



    }


    // Update is called once per frame
    async void Update()
    {
        Debug.Log(leftBound.x);
        if (leftBound.x != 0 && rightBound.x != 0)
        {
            Debug.Log("nan");
            before = gameObject.transform.position;
            gameObject.transform.position = new Vector2(Mathf.PingPong((Time.time / 2), rightBound.x - leftBound.x) + leftBound.x, gameObject.transform.position.y);
            current = gameObject.transform.position;
        }






        if (before.x > current.x)
        {
            currtentWay = "r";
        }
        else
        {
            currtentWay = "l";
        }
        if (!(currtentWay == isLeft))
        {
            gameObject.transform.Rotate(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z);

        }
        isLeft = currtentWay;



    }


}
