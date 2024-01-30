using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KameraSinir : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    GameManager managerObject = new GameManager();
   

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("bitti");
            managerObject.LoadEndGame();
            // buraya oyun bitti gelecek

        }
    }
}

