using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTheBear : MonoBehaviour
{

    public GameObject bearHead;
    public GameObject bear;

    public bool isBearDead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("BearHead"))
        {
            Destroy(bear);
            isBearDead = true;
            Debug.Log("collide with bearHEad");

        }
    }

}
