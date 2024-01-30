using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    private Animator anim;
    private GameObject player;


    GameManager managerObject = new GameManager();
    
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.Find("Player");
        
        rb = GetComponent<Rigidbody2D>();
        
        anim = GetComponent<Animator>();
    }


   

    // Update is called once per frame
    void Update()
    {
        
    }


    private void Die()
    {
        
        
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("bitti");
            managerObject.RestartGame();
            // buraya oyun bitti gelecek

        }
        //if (collision.gameObject.CompareTag("Thorn") || player.GetComponent<KillTheBear>().isBearDead)
        //{
        //    Die();

        //    // buraya olum ekraný gelecek

        //    managerObject.LoadEndGame();
        //}

        // if bear is dead, player can't die
        if (player.GetComponent<KillTheBear>().isBearDead)
        {
            return;
        }

        //if bear is not dead, player can die
        if (collision.gameObject.CompareTag("Thorn"))
        {
            Die();

            // buraya olum ekraný gelecek

            managerObject.LoadEndGame();
        }   

        

    }
    
}
