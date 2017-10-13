using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float score = 0;
    [SerializeField]
    private float highScore;
    [SerializeField]
    private float scoreMultiplier = 100;
    private Text scoreCounter;

    [SerializeField]
    private int coins = 0;
    private Text coinCounter;

    private void OnLevelWasLoaded(int level)
    {
        scoreCounter = GameObject.FindWithTag("ScoreCounter").GetComponent<Text>();
        coinCounter = GameObject.FindWithTag("CoinCounter").GetComponent<Text>();
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetFloat("highScore", 0);
        coins = PlayerPrefs.GetInt("coins", 0);
    }

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        if (!GetComponent<PlayerDeath>().isDead)
        {
            score += Time.deltaTime * scoreMultiplier;
            scoreCounter.text = "Score: " + (int)score;
        }
    }

    public void AddCoin(int amount)
    {
        coins += amount;

        coinCounter.text = "Coins: " + coins.ToString();
    }
}
