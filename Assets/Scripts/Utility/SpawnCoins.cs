using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    public GameObject coin;

    [SerializeField]
    private bool spawnOnStart = false;
    [SerializeField]
    private bool random = false;

    private void Start()
    {
        if (spawnOnStart)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        if ((random && Random.Range(0, 2) == 1) || !random)
        {
            for (int i = 0; i < GetComponent<SpriteRenderer>().bounds.size.x / coin.GetComponent<SpriteRenderer>().bounds.size.x - 1; i++)
            {
                GameObject coinInstance = Instantiate(coin);
                coinInstance.transform.position = new Vector2
                    ((transform.position.x - GetComponent<SpriteRenderer>().bounds.size.x / 2 + coin.GetComponent<SpriteRenderer>().bounds.size.x / 2) + coin.GetComponent<SpriteRenderer>().bounds.size.x * i,
                    transform.position.y + GetComponent<SpriteRenderer>().bounds.size.y / 2 + coin.GetComponent<SpriteRenderer>().bounds.size.y / 2);
            }
        }
    }
}
