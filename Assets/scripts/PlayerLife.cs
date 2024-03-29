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


    [SerializeField]
    private GameObject kamerasinir;
    

    private void Awake() 
    {
        kamerasinir = GameObject.Find("KameraSınır");
    }


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



    /*
    // doing nothing for now
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        
    }
    */

  


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if bear is not dead, player can die
        if (collision.gameObject.CompareTag("Thorn") || collision.gameObject.CompareTag("Bear"))
        {
            
            

            // if isLevel2 not true(level1) and remeningLife is > 0 spawn player2
            if (kamerasinir.GetComponent<KameraSinir>().remeningLives > 0  && kamerasinir.GetComponent<KameraSinir>().isLevel2)
            {
                kamerasinir.GetComponent<KameraSinir>().DecreaseLives(); // decrease lives and update text
                kamerasinir.GetComponent<KameraSinir>().StopPlayer1(); // stop player1
                kamerasinir.GetComponent<KameraSinir>().StartPlayer2(); // start player2
            }
            if (kamerasinir.GetComponent<KameraSinir>().remeningLives <= 0)
            {
                managerObject.LoadEndGame();
            }


        }

        


        // if player collide with bear head, bear will die but player can't die anymore
        else if (collision.gameObject.CompareTag("BearHead"))
        {
            
            player.GetComponent<KillTheBear>().isBearDead = true;
            Debug.Log("collide with bear head"); 
            // don't call Die() functio
        }
        
        else if (player.GetComponent<KillTheBear>().isBearDead)
        {
            return;
        }

    }
    
}
