using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite[] sprites;

    public float frameRate = 24;

    public bool playAutomatically = true;
    public bool loop = true;

    public bool scaledTime = true;

    [SerializeField]
    private bool destroyAutomatically = false;

    private bool isPlaying = true;

    private float startTime;
    private float unscaledStartTime;

    /// <summary>
    /// Returns whether the animation is playing
    /// </summary>
    public bool IsPlaying
    {
        get
        {
            return isPlaying;
        }
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        startTime = Time.time;
        unscaledStartTime = Time.unscaledTime;
    }

    private void Start()
    {
        isPlaying = playAutomatically;

        if (destroyAutomatically)
        {
            Destroy(gameObject, Length());
        }
    }

    private void Update()
    {
        if (isPlaying)
        {
            float time = scaledTime ? Time.time - startTime : Time.unscaledTime - unscaledStartTime;

            int index = (int)((time * frameRate) % sprites.Length);

            spriteRenderer.sprite = sprites[index];

            if (!loop && index == sprites.Length - 1)
            {
                isPlaying = false;
            }
        }
    }

    /// <summary>
    /// Play the animation
    /// </summary>
    public void Play()
    {
        isPlaying = true;
    }

    /// <summary>
    /// Stop the animation
    /// </summary>
    public void Stop()
    {
        isPlaying = false;

        spriteRenderer.sprite = sprites[0];
    }

    /// <summary>
    /// Length of the animation in seconds
    /// </summary>
    /// <returns></returns>
    public float Length()
    {
        return (sprites.Length) / frameRate;
    }
}
