using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private Animator animator;

    private bool grounded;

    private float speed;

    [SerializeField]
    private float startSpeed = 4;
    [SerializeField]
    private float maxSpeed = 12;
    [SerializeField]
    private float maxJumpHeight = 3;
    [SerializeField]
    private float jumpPower = 6;

    [SerializeField]
    private AudioClip[] jumpClips;

    private float groundedRaycastSize = 0.1f;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        speed = startSpeed;
    }

    private void Update()
    {
        rb2D.velocity = new Vector2(speed, rb2D.velocity.y);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && grounded)
        {
            StartCoroutine(Jump());
            audioSource.PlayOneShot(jumpClips[Random.Range(0, jumpClips.Length)]);
        }

        animator.SetBool("grounded", grounded);

        speed = Mathf.Lerp(speed, maxSpeed, Time.deltaTime / 500);
    }

    private void FixedUpdate()
    {
        Vector2 raycastStart = new Vector2(transform.position.x, transform.position.y - spriteRenderer.sprite.bounds.size.y / 2);

        RaycastHit2D[] hits = Physics2D.RaycastAll(raycastStart, Vector2.down, groundedRaycastSize);

        List<string> tagList = new List<string>();

        for (int i = 0; i < hits.Length; i++)
        {
            tagList.Add(hits[i].collider.tag);
        }

        grounded = tagList.Contains("Ground");
    }

    private IEnumerator Jump()
    {
        float _maxJumpHeight = transform.position.y + maxJumpHeight;
        float _jumpPower = jumpPower;

        while (Input.GetButton("Jump") && transform.position.y < _maxJumpHeight)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, _jumpPower);

            _jumpPower -= 0.1f;

            yield return null;
        }
    }
}
