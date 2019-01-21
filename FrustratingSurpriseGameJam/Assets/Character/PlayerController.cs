using System;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    public enum Direction { LEFT, RIGHT, UP, DOWN, UP_LEFT, UP_RIGHT, DOWN_LEFT, DOWN_RIGHT };
    [SerializeField] public float MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
    [SerializeField] public float CrouchSpeedMultiplier = 0.4f;     // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [SerializeField] public float JumpForce = 400f;                  // Amount of force added when the player jumps.
    [SerializeField] public float LightJumpForce = 200f;                  // Amount of force added when the player jumps.
    
    [SerializeField] private LayerMask MapLayer;                  // A mask determining what is ground to the character
    private Animator m_Anim;            // Reference to the player's animator component.
    private Rigidbody2D m_Rigidbody2D;
    private BoxCollider2D m_collider;
    
    private bool Grounded = true;            // Whether or not the player is grounded.
    private bool Crouching = false;
    private Direction direction;

    // Use this for initialization
    private void Awake () {

        m_Anim = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_collider = GetComponent<BoxCollider2D>();
    }



    private void FixedUpdate()
    {
        RaycastHit2D[] right_raycast = Physics2D.RaycastAll(new Vector2(transform.position.x + m_collider.size.x / 2, transform.position.y), Vector2.down, m_collider.size.y / 2, MapLayer);
        RaycastHit2D[] left_raycast = Physics2D.RaycastAll(new Vector2(transform.position.x - m_collider.size.x / 2, transform.position.y), Vector2.down, m_collider.size.y / 2, MapLayer);

        Grounded = (right_raycast.Length > 0 || left_raycast.Length > 0);
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, m_collider.size, 0, MapLayer);
        m_Anim.SetBool("Ground", Grounded);

        // Set the vertical animation
        m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
    }


    public void Move(float move, bool crouch_pressed, int jump)
    {
        // If crouching, check to see if the character can stand up
        if (!crouch_pressed && m_Anim.GetBool("Crouch"))
        {
            RaycastHit2D[] right_raycast = Physics2D.RaycastAll(new Vector2(transform.position.x + m_collider.size.x / 2, transform.position.y), Vector2.up, m_collider.size.y / 2, MapLayer);
            RaycastHit2D[] left_raycast = Physics2D.RaycastAll(new Vector2(transform.position.x - m_collider.size.x / 2, transform.position.y), Vector2.up, m_collider.size.y / 2, MapLayer);

            Crouching = (right_raycast.Length > 0 || left_raycast.Length > 0);
        }

        // Set whether or not the character is crouching in the animator
        m_Anim.SetBool("Crouch", Crouching);

        // Reduce the speed if crouching by the crouchSpeed multiplier
        move = (Crouching ? move * CrouchSpeedMultiplier : move);

        // The Speed animator parameter is set to the absolute value of the horizontal input.
        m_Anim.SetFloat("Speed", Mathf.Abs(move));

        // Move the character
        m_Rigidbody2D.velocity = new Vector2(move * MaxSpeed, m_Rigidbody2D.velocity.y);

        // If the player should jump...
        if (Grounded && jump > 0 && m_Anim.GetBool("Ground"))
        {
            Grounded = false;
            m_Anim.SetBool("Ground", false);
            m_Rigidbody2D.AddForce(new Vector2(0f, jump == 1 ? JumpForce : LightJumpForce));
        }
        else
            jump = 0;


        if (move > 0)
        {
            if (Crouching)      direction = Direction.DOWN_RIGHT;
            else if (jump > 0)  direction = Direction.UP_RIGHT;
            else                direction = Direction.RIGHT;
        }
        else if (move < 0)
        {
            if (Crouching)      direction = Direction.DOWN_LEFT;
            else if (jump > 0)  direction = Direction.UP_LEFT;
            else                direction = Direction.LEFT;
        }
        
 
    }
    
}

