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

    public GameObject GameManagerObject;

    public int remeningLives = 2;

    [SerializeField]
    private int level2StartPos = 15;

    //public Vector2 level2StartPos = new Vector2(-0.610000014f,1.70000005f);

    public TextMeshProUGUI livesTextTMP = null;

 
    public GameManager managerObject = new GameManager();

   private void Awake() 
   {
        playerForLevel2 = GameObject.Find("PlayerForLevel2");
        StopPlayer2();
        
        
        livesTextTMP = GameObject.Find("Canvas/Life (TMP)").GetComponent<TextMeshProUGUI>();

        managerObject = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerForLevel1 = GameObject.Find("Player");
   }

   private void Start() {
        
   }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;

        if (player.position.y > level2StartPos && !isLevel2)
        {
            isLevel2 = true;
            remeningLives = 2;
            Debug.Log("level 2 ulasıldi");
            livesTextTMP.text = remeningLives.ToString();

            // buraya texti gostermek yerine bir canı olduğunu gosteren bir can simgesi koyulabilir

        }
        else if (player.position.y < level2StartPos)
        {
            isLevel2 = false;
            remeningLives = 0;
        }   
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (remeningLives > 0 && isLevel2)
            {
                remeningLives--;
                livesTextTMP.text = remeningLives.ToString();
                Debug.Log("Kalan can: " + remeningLives );
                StopPlayer1();
                StartPlayer2();
            }
            if(remeningLives <= 0)
            {
                Debug.Log("can kalmadı " + remeningLives);
                livesTextTMP.text = remeningLives.ToString();
                managerObject.LoadEndGame();
            }
        }
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

    public void StopPlayer2()
    {
        playerForLevel2.GetComponent<Collider2D>().enabled = false;
        playerForLevel2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        playerForLevel2.GetComponent<SpriteRenderer>().enabled = false;
    }



}



