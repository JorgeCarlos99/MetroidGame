using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float moveInput;
    public float jumpForce;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    bool isGrounded;
    public Transform checkGround;
    public float checkRadius;
    public LayerMask groundMask;
    private float algo = 1f;
    public bool canMove = true;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Pref lvl 1: " + PlayerPrefs.GetFloat("volume"));
        Debug.Log("Pref lvl 1 Vidas: " + PlayerPrefs.GetFloat("vidas"));
    }

    // Update is called once per frame
    void Update()
    {
        // Flip the Player facing right and left
        if (moveInput > 0 && facingRight == false && canMove)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight == true && canMove)
        {
            Flip();
        }

        // Para poner la preferencia del player y guardar cosas
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Debug.Log("Antes: " + PlayerPrefs.GetFloat("volume"));
            // PlayerPrefs.SetFloat("volume", algo++);
            // Debug.Log("Despues: " + PlayerPrefs.GetFloat("volume"));

            PlayerPrefs.SetFloat("vidas", algo++);
            Debug.Log(PlayerPrefs.GetFloat("vidas"));
        }

        isGrounded = Physics2D.OverlapCircle(checkGround.position, checkRadius, groundMask);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetButton("Jump") && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;
    }
}
