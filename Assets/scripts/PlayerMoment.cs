using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMoment : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Rigidbody2D rb;
    public float jumpStrength;
    public float moveSpeed;
    private BoxCollider2D coll;
    public float dirX;

    public bool doubleJump = false;
    
    [SerializeField] private LayerMask jumpableGraound;

    // tavsan oyun basi animasyon
    private Animator animator;
    private bool gameStarted = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

        
       


    }


    void Update()
    {
        
        
        dirX = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButton("Horizontal")){
        rb.velocity = new Vector2( dirX * moveSpeed,rb.velocity.y);
        }
        
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = Vector2.up * jumpStrength;
        }
       else if (Input.GetButtonDown("Jump") && doubleJump )
       {
            rb.velocity = Vector2.up * jumpStrength;
            doubleJump=false;
       }
       
        UpdateAnimationUpdate();

        

    } 
    void UpdateAnimationUpdate()
    {
        
        if(dirX >0f)
        {
            sprite.flipX= false;
        }
        else if (dirX < 0f)
        {
            sprite.flipX=true;
        }
        else
        {

        };

        
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f,Vector2.down, .1f, jumpableGraound);
    }



}
