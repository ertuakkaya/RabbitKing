using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class KameraSinir : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public bool isLevel2 = false;
    public GameObject playerForLevel2;
    public GameObject playerForLevel1;

    public int remeningLives = 3;

    public Vector2 level2StartPos = new Vector2(-0.610000014f,1.70000005f);

    public TextMeshProUGUI livesTextTMP = null;

    //GameManager managerObject = new GameManager();

    // GameManager's instance object 

    
    public GameManager managerObject = new GameManager();

   private void Awake() 
   {
        //managerObject = GameManager.instance;
        
        playerForLevel2 = GameObject.Find("PlayerForLevel2");
        playerForLevel2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        playerForLevel2.GetComponent<Collider2D>().enabled = false;
        livesTextTMP = GameObject.Find("Canvas/Life (TMP)").GetComponent<TextMeshProUGUI>();
        livesTextTMP.text = remeningLives.ToString();

        playerForLevel1 = GameObject.Find("Player");
   }

   private void Start() {
        
   }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;

        if (player.position.y > 5)
        {
            isLevel2 = true;
            Debug.Log("level 2 ulasıldi");
        }


    }


    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (remeningLives > 0 && isLevel2)
            {
                remeningLives--;
                Debug.Log("Kalan can: " + remeningLives );
                // spawn player to level 1 start position
                //player.transform.position = level2StartPos;
                playerForLevel1.GetComponent<SpriteRenderer>().enabled = false;
                playerForLevel1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                playerForLevel1.GetComponent<Collider2D>().enabled = false;

                playerForLevel2.GetComponent<Collider2D>().enabled = true;
                playerForLevel2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                playerForLevel2.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if(remeningLives <= 0)
            {
                Debug.Log("can kalmadı " + remeningLives);
                managerObject.LoadEndGame();
            }
            
            
            
            
        }
       

  
        

    }
}

