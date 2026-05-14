using System;
using UnityEngine;

public class PlayereTest : MonoBehaviour
{
    [SerializeField] float JumpForce = 1.0f;
    [SerializeField] float MoveForce = 1.0f;
    Rigidbody2D rb;

    private Animator animator;
    private bool isGround = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool touch = false;

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touch = true;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            touch = true;
        }

        if (touch)
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }

#if UNITY_EDITOR
        rb.AddForce(Vector2.right * MoveForce * Time.deltaTime);
#else
        rb.AddForce(Vector2.right * MoveForce * Input.acceleration.x * Time.deltaTime);
#endif
        animator.SetBool("IsGround",isGround);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Field")
        {
            isGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Field")
        {
            isGround = false;
        }
    }
}
