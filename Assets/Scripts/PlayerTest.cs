using System;
using UnityEngine;

public class PlayereTest : MonoBehaviour
{
    [SerializeField] float JumpForce = 1.0f;
    [SerializeField] float MoveForce = 1.0f;
    [SerializeField] GameObject Explosion;

    [SerializeField] AudioClip jumAudioClip;
    [SerializeField] AudioClip landAudioClip;
    [SerializeField] AudioClip boneAudioClip;

    [SerializeField] Score score;

    AudioSource audioSource;

    Rigidbody2D rb;

    private Animator animator;
    private bool isGround = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(jumAudioClip);
        }

        if (touch)
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }

#if UNITY_EDITOR
        rb.AddForce(Vector2.right * (MoveForce * Time.deltaTime));
#else
        rb.AddForce(Vector2.right * MoveForce * Input.acceleration.x * Time.deltaTime);
#endif
        animator.SetBool("IsGround",isGround);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Field"))
        {
            isGround = true;
            audioSource.PlayOneShot(landAudioClip);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Field"))
        {
            isGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bone"))
        {
            Destroy(collision.gameObject);

            GameObject newExplosion = Instantiate(Explosion,
                collision.gameObject.transform.position,
                Quaternion.identity);

            Destroy(newExplosion,1.0f);
            
            audioSource.PlayOneShot(boneAudioClip);

            score.AddScore(100);
        }
    }
}
