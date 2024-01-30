using UnityEngine;



public class CarrotDestory : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == "Player")
        {
            ScoreManager.instance.AddPoint();
            Debug.Log(" getting star ");
            Destroy(gameObject);

        }
    }
    
    
    private void OnCollisionEnter2D(Collision2D other) 
    
    {
        
    }

}
