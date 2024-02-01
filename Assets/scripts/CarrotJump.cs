using UnityEngine;

public class CarrotJump : MonoBehaviour
{

    private GameObject doubleJumpImage;
    private GameObject player;

    

    private void Start()
    {

        doubleJumpImage = GameObject.Find("DoubleJumpImage");
        player = GameObject.Find("Player");
        


        // debug 
        if (doubleJumpImage == null)
        {
            Debug.LogError("DoubleJumpImage not assigned in the editor.");
            
        }

        if (player == null)
        {
            Debug.LogError("Player not assigned in the editor.");
            
        }

       
        doubleJumpImage.GetComponent<SpriteRenderer>().enabled = false;
        //Debug.Log("DoubleJumpImage is set to false Start");
        


    }


    private void Update()
    {
        if (player.GetComponent<PlayerMoment>().doubleJump == false)
        {
            doubleJumpImage.GetComponent<SpriteRenderer>().enabled = false;
            //Debug.Log("DoubleJumpImage is set to false Update");


        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            doubleJumpImage.GetComponent<SpriteRenderer>().enabled = true;
            ScoreManager.instance.AddPoint();
            Debug.Log(" getting star ");
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerMoment>().doubleJump = true;
        }

        
    }
}
