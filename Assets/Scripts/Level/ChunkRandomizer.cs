using UnityEngine;

public class ChunkRandomizer : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private int maxEnemies = 3;

    [SerializeField]
    private GameObject coin;

    [SerializeField]
    private GameObject platform;
    [SerializeField]
    private float maxPlatformHeight = 2;

    [SerializeField]
    private float distanceFromEdge = 4;

    private enum ChunkType { coinFull, platforms, empty, enemies }
    private ChunkType chunkType;

    private static int chunkCount = 0;

    private void Start()
    {
        if (chunkCount == 0)
        {
            RandomizeChunk(ChunkType.empty);
        }
        else
        {
            RandomizeChunk((ChunkType)Random.Range(0, System.Enum.GetNames(typeof(ChunkType)).Length));
        }
    }

    private void RandomizeChunk(ChunkType type)
    {
        chunkType = type;

        switch (chunkType)
        {
            case ChunkType.coinFull:

                SpawnCoins spawnCoins = gameObject.AddComponent<SpawnCoins>();
                spawnCoins.coin = coin;
                spawnCoins.Spawn();

                break;
            case ChunkType.enemies:

                int enemyAmount = Random.Range(1, maxEnemies);

                for (int i = 0; i < enemyAmount; i++)
                {
                    GameObject enemyInstance = Instantiate(enemies[Random.Range(0, enemies.Length)]);

                    Vector2 enemyPosition = new Vector2
                        (transform.position.x - GetComponent<SpriteRenderer>().bounds.size.x / 2 + distanceFromEdge + (Random.Range(0, GetComponent<SpriteRenderer>().bounds.size.x - distanceFromEdge)),
                        transform.position.y + GetComponent<SpriteRenderer>().bounds.size.y / 2 + enemyInstance.GetComponent<SpriteRenderer>().bounds.size.y / 2);

                    enemyInstance.transform.position = enemyPosition;

                    /*while()
                    {

                    }*/
                }

                break;
            case ChunkType.platforms:

                GameObject platformInstance = Instantiate(platform);
                SpriteRenderer platformSpriteRenderer = platformInstance.GetComponent<SpriteRenderer>();

                Vector2 platformSize = new Vector2(Random.Range(2, 6), platformInstance.GetComponent<SpriteRenderer>().size.y);

                platformSpriteRenderer.size = platformSize;
                platformInstance.GetComponent<BoxCollider2D>().size = platformSize;

                Vector2 platformPosition = new Vector2
                    (transform.position.x - GetComponent<SpriteRenderer>().bounds.size.x / 2 + distanceFromEdge + (Random.Range(0, GetComponent<SpriteRenderer>().bounds.size.x - distanceFromEdge)),
                    transform.position.y + GetComponent<SpriteRenderer>().bounds.size.y / 2 + platformSpriteRenderer.bounds.size.y / 2 + Random.Range(maxPlatformHeight, maxPlatformHeight+1));

                platformInstance.transform.position = platformPosition;

                break;
        }

        chunkCount++;
    }
}
