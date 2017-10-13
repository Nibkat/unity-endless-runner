using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerStats>())
        {
            GetComponent<Renderer>().enabled = false;

            collision.GetComponent<PlayerStats>().AddCoin(1);

            audioSource.Play();

            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
