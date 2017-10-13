using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
public class PlayerDeath : MonoBehaviour
{
    private PlayerController playerController;
    private AudioSource audioSource;
    private Animator animator;
    private Rigidbody2D rb2D;
    private Collider2D col2D;

    [SerializeField]
    private AudioClip[] deathClips;
    [SerializeField]
    private AudioClip[] fallingDeathClips;

    public bool isDead;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        col2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (transform.position.y <= -10)
        {
            Die(true);
        }
    }

    public void Die(bool falling)
    {
        if (!isDead)
        {
            animator.SetBool("dead", true);

            playerController.enabled = false;

            rb2D.constraints = RigidbodyConstraints2D.None;

            if (!falling)
            {
                audioSource.PlayOneShot(deathClips[Random.Range(0, deathClips.Length)]);

                rb2D.AddForce(Vector2.up * 400);
                rb2D.AddForce(Vector2.left * 300);
                rb2D.AddTorque(25);
            }
            else
            {
                if (fallingDeathClips.Length > 0)
                {
                    audioSource.PlayOneShot(fallingDeathClips[Random.Range(0, fallingDeathClips.Length)]);
                }
                else
                {
                    audioSource.PlayOneShot(deathClips[Random.Range(0, deathClips.Length)]);
                }

                rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            }

            col2D.sharedMaterial = null;

            isDead = true;

            Object[] objects = FindObjectsOfType(typeof(GameObject));
            foreach (GameObject go in objects)
            {
                go.SendMessage("OnPlayerDied", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
