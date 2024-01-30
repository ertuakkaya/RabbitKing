using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class GameManager : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {

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
