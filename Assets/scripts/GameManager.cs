using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


[ExecuteInEditMode]
public class GameManager : MonoBehaviour
{

    


    //public static GameManager instance = new GameManager();
    public int level;



    
    

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("LevelDesign");
    }

    public void LoadEndGame() 
    {
        SceneManager.LoadScene("LoseScreen");
    }


    
    

}
