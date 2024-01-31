using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerTest : MonoBehaviour
{

    CharacterController characterController;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            characterController.Move(new Vector3(-1, 0, 0) * Time.deltaTime); // move left
        else if (Input.GetKey(KeyCode.D))
            characterController.Move(new Vector3(1, 0, 0) * Time.deltaTime); // move right
        else if (Input.GetKey(KeyCode.Space))
            characterController.Move(new Vector3(0, 1, 0) * Time.deltaTime); // move up
        
        
        
    }
}
