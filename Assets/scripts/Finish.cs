using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("PlayerWinAnim", false);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {

            CompleteLevel();
            
            animator = GetComponent<Animator>();
            animator.SetBool("PlayerWinAnim", true);
        }

    }

    

    private void CompleteLevel()
    {
        // buraya oyun sonu sahnesi gelecek

        SceneManager.LoadScene("EndGame");

    }


}