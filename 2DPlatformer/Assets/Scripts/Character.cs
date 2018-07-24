using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public int lives = 3;
    public float speed = 4.0f;
    public float jumpforce = 1.0f;
    public Rigidbody2D PlayerRigidbody;
    public Animator charAnimation;
    public SpriteRenderer Sprite;
    bool OnGround;
    
    private void Awake()
    {
        PlayerRigidbody = gameObject.GetComponentInChildren<Rigidbody2D>();
        charAnimation = gameObject.GetComponentInChildren<Animator>();
        Sprite = gameObject.GetComponentInChildren<SpriteRenderer>();



    }

    void Start ()
    {
		
	}

    void Move()
    {
        Vector3 tempvector = Vector3.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + tempvector, speed * Time.deltaTime);
        if(tempvector.x<0)
        {
            Sprite.flipX = true;
        }
        else
        {
            Sprite.flipX = false;
        }
    }

    void Jump()
    {
        PlayerRigidbody.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
    }

    void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        OnGround = colliders.Length  > 1;
         }

    private void FixedUpdate()
    {
        CheckGround();
    }

    void Update ()
    {
		if(Input.GetButton("Horizontal"))
        {
            Move();
            charAnimation.SetInteger("State", 1);
        }
        else
        {
            charAnimation.SetInteger("State", 0);
        }

        if (Input.GetButton ("Jump"))
        {
            Jump();
            charAnimation.SetInteger("State", 2);
        }

    }
}
