using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class character : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D r2d;
    private Animator _animator;
    private Vector3 characterPos;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _camera;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        r2d = GetComponent<Rigidbody2D>(); //caching 
        _animator = GetComponent<Animator>();
        characterPos = transform.position;
        
    }

    public void FixedUpdate()
    {
        //r2d.velocity = new Vector2(speed, 0f);
    }

    // Update is called once per frame
    void Update() //per frame 
    {
        
        characterPos = new Vector3(characterPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), characterPos.y);
        transform.position = characterPos; //Hesaplanan pozisyon karaktere iþlensin
        if(Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", speed);
        }
        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }
        else if(Input.GetAxis("Horizontal") < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void LateUpdate()
    {
        _camera.transform.position = new Vector3(characterPos.x,characterPos.y,characterPos.z - 1.0f);
    }
}
