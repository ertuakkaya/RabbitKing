using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//using System.Diagnostics;

public class KameraSinir : MonoBehaviour
{
    public Transform player;

    [SerializeField]
    private Image LivesImage;
    
    
    


    public Vector3 offset;
    public bool isLevel2 = false;
    public bool isLevel3 = false;
    public GameObject playerForLevel2;
    public GameObject playerForLevel1;

    public GameObject playerForLevel3;

    public GameObject GameManagerObject;

    public int remeningLives = 2;

    [SerializeField]
    private int level2StartPos = 15;
    [SerializeField]
    private int level3StartPos = 20;

    //public Vector2 level2StartPos = new Vector2(-0.610000014f,1.70000005f);

    public TextMeshProUGUI livesTextTMP = null;

 
    public GameManager managerObject = new GameManager();

   private void Awake() 
   {
        
        playerForLevel1 = GameObject.Find("Player");
        playerForLevel2 = GameObject.Find("PlayerForLevel2");
        playerForLevel3 = GameObject.Find("PlayerForLevel3");
        StopPlayer2(); // baslangicta player2 yi durdur
        StopPlayer3(); // baslangicta player3 u durdur
        
        LivesImage = GameObject.Find("Canvas/LiveImage").GetComponent<Image>();
        LivesImage.enabled = false;
        
        
        
        
        
        livesTextTMP = GameObject.Find("Canvas/Life (TMP)").GetComponent<TextMeshProUGUI>();

        managerObject = GameObject.Find("GameManager").GetComponent<GameManager>();
        
   }

   private void Start() {
        
   }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset; 

        if (player.position.y > level2StartPos && !isLevel2 && !isLevel3) // level1'den level2 ye geçiş
        {
            
            isLevel3 = false;
            isLevel2 = true;
            

            LivesImage.enabled = true;
            remeningLives = 2;
            UnityEngine.Debug.Log("level 2 ulasıldi");
            livesTextTMP.text = remeningLives.ToString();

            // buraya texti gostermek yerine bir canı olduğunu gosteren bir can simgesi koyulabilir

        }
        else if (playerForLevel2.transform.position.y >= level3StartPos && !isLevel3 && isLevel2) // level2'den level 3 e geçiş
        {
            isLevel2 = false;
            isLevel3 = true;
            
            LivesImage.enabled = true;
            remeningLives = 2;
            UnityEngine.Debug.Log("level 3 ulasıldi");
            livesTextTMP.text = remeningLives.ToString();
        }
        else if (player.position.y < level2StartPos && !isLevel2 && !isLevel3) // oyun baslangici level 1
        {
            isLevel2 = false;
            isLevel3 = false;
            remeningLives = 0;
            LivesImage.enabled = false;
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (remeningLives > 0 && (isLevel2 || isLevel3))
            {
                

                //StopPlayer1(); // stop player1
                //StopFormerPlayer(); // stop former player
                StartCoroutine(StopFormerPlayerCoroutine());


                //StartPlayer2(); // start player2
                //StartNextPlayer(); // start next player
                StartCoroutine(StartNextPlayerCoroutine());

                //DecreaseLives(); // decrease lives and update text
                StartCoroutine(DecreaseLivesCoroutine());


            }
            if(remeningLives <= 0)
            {
                Debug.Log("can kalmadı " + remeningLives);
                livesTextTMP.text = remeningLives.ToString();
                managerObject.LoadEndGame();
            }
        }
    }


    public void DecreaseLives()
    {
        if (remeningLives > 0)
        {
            remeningLives--;
            LivesImage.enabled = false;
            livesTextTMP.text = remeningLives.ToString();
            Debug.Log("Kalan can: " + remeningLives );
        }
        else
        {
            Debug.Log("can kalmadı " + remeningLives);
            managerObject.LoadEndGame();

            
        }
    }

    public void IncreaseLives()
    {
        remeningLives++;
        livesTextTMP.text = remeningLives.ToString();
        Debug.Log("Kalan can: " + remeningLives );
    }

    public void StopPlayer1()
    {
        playerForLevel1.GetComponent<SpriteRenderer>().enabled = false;
        playerForLevel1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        playerForLevel1.GetComponent<Collider2D>().enabled = false;
    }

    public void StartPlayer2()
    {
        playerForLevel2.GetComponent<Collider2D>().enabled = true;
        playerForLevel2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        playerForLevel2.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void StartPlayer3()
    {
        playerForLevel3.GetComponent<Collider2D>().enabled = true;
        playerForLevel3.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        playerForLevel3.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void StopPlayer2()
    {
        playerForLevel2.GetComponent<Collider2D>().enabled = false;
        playerForLevel2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        playerForLevel2.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void StopPlayer3()
    {
        playerForLevel3.GetComponent<Collider2D>().enabled = false;
        playerForLevel3.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        playerForLevel3.GetComponent<SpriteRenderer>().enabled = false;
    }

    
    /*
    public void StopFormerPlayer()
    {
        if (isLevel2)
        {
            StopPlayer1();
        }
        if (isLevel3)
        {
            StopPlayer2();
        }
    }

    public void StartNextPlayer()
    {
        if (isLevel2)
        {
            StartPlayer2();
        }
        if (isLevel3)
        {
            StartPlayer3();
        }
    }
    
    */

    IEnumerator StopFormerPlayerCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        if (isLevel2)
        {
            StopPlayer1();
        }
        if (isLevel3)
        {
            StopPlayer2();
        }
    }

    IEnumerator StartNextPlayerCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        if (isLevel2)
        {
            StartPlayer2();
        }
        if (isLevel3)
        {
            StartPlayer3();
        }
    }

    IEnumerator DecreaseLivesCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        if (remeningLives > 0)
        {
            remeningLives--;
            LivesImage.enabled = false;
            livesTextTMP.text = remeningLives.ToString();
            Debug.Log("Kalan can: " + remeningLives );
        }
        else
        {
            Debug.Log("can kalmadı " + remeningLives);
            managerObject.LoadEndGame();
            
        }
    }

    


}



