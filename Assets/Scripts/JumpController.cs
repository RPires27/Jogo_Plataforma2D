using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{

    Rigidbody2D rb;
    public int ForcaDeSalto;

    public Transform groundCheck;
    public LayerMask layerMask;
    public Animator animator;
   
    bool isGrounded;

    bool doubleJump;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.5f, 0.10f), CapsuleDirection2D.Horizontal, 0, layerMask);
        if (Input.GetButtonDown("Jump") && (isGrounded || doubleJump))
        {
            rb.velocity = new Vector2(rb.velocity.x, ForcaDeSalto);
            doubleJump = !doubleJump;
        }
        animator.SetBool("saltar",isGrounded);
    }
}
