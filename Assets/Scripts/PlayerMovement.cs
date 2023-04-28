using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Pref lvl 1: " + PlayerPrefs.GetFloat("volume"));

    }

    // Update is called once per frame
    void Update()
    {
        // Para poner la preferencia del player y guardar cosas
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("Antes: " + PlayerPrefs.GetFloat("volume"));
            PlayerPrefs.SetFloat("volume", algo++);
            Debug.Log("Despues: " + PlayerPrefs.GetFloat("volume"));
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
}
