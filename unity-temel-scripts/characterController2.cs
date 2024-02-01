using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController2 : MonoBehaviour
{
    public float jumpForce = 2.0f;
    public float speed = 1.0f;
    public float moveDirection;

    private bool jump;
    private bool isMoving;
    private bool isGrounded = true;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;


    private void Awake()
    {
        _animator = GetComponent<Animator>(); //caching animator

    }
    private void Start()
    {
       _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (_rigidbody2D.velocity != Vector2.zero)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        _rigidbody2D.velocity = new Vector2(speed * moveDirection, _rigidbody2D.velocity.y);

        if (jump == true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            jump = false;
        }
    }

    private void Update()
    {
        if(isGrounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if(Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _spriteRenderer.flipX = true;
                _animator.SetFloat("speed", speed);
            }
            else if(Input.GetKey(KeyCode.D)) 
            { 
                moveDirection = 1.0f;
                _spriteRenderer.flipX = false;
                _animator.SetFloat("speed", speed);
            }
        }
        else if (isGrounded == true)
        {
            moveDirection = 0.0f;
            _animator.SetFloat("speed", 0.0f);
        }

        if (isGrounded == true && Input.GetKey(KeyCode.W)) 
        {
            jump = true;
            isGrounded = false;
            _animator.SetTrigger("jump");
            _animator.SetBool("grounded", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Zemin"))
        {
            _animator.SetBool("grounded", true);
            isGrounded = true;
        }
        
    }
}
