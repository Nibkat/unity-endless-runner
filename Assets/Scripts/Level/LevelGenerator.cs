using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject chunk;

    [SerializeField]
    private Vector2 chunkWidthMinMax;
    [SerializeField]
    private float chunkHeight = 3f;

    [SerializeField]
    private Vector2 gapWidthMinMax;

    [SerializeField]
    private int initialChunks = 8;

    private float cameraWorldPointY = 0.05f;

    private List<GameObject> spawnedChunks = new List<GameObject>();

    private void Start()
    {
        cameraWorldPointY = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.05f)).y;

        for (int i = 0; i < initialChunks; i++)
        {
            SpawnChunk();
        }
    }

    private void LateUpdate()
    {
        for (int i = 0; i < spawnedChunks.Count; i++)
        {
            if (spawnedChunks[i].transform.position.x < Camera.main.ViewportToWorldPoint(new Vector3(0 - 1, 0, 0)).x)
            {
                Destroy(spawnedChunks[0]);
                spawnedChunks.RemoveAt(0);

                SpawnChunk();

                spawnedChunks.Sort((p1, p2) => p1.transform.position.x.CompareTo(p2.transform.position.x));
            }
        }
    }

    private void SpawnChunk()
    {
        GameObject chunkInstance = Instantiate(chunk);

        Vector2 chunkSize = new Vector2(Random.Range(chunkWidthMinMax.x, chunkWidthMinMax.y), chunkHeight);

        chunkInstance.GetComponent<SpriteRenderer>().drawMode = SpriteDrawMode.Tiled;
        chunkInstance.GetComponent<SpriteRenderer>().size = chunkSize;
        chunkInstance.GetComponent<BoxCollider2D>().size = chunkSize;

        if (spawnedChunks.Count <= 0)
        {
            Vector2 firstChunkPosition = new Vector2(GameObject.FindWithTag("Player").transform.position.x, cameraWorldPointY);
            chunkInstance.transform.position = firstChunkPosition;
        }
        else
        {
            float gapWidth = 0;

            if (spawnedChunks.Count % 1 == 0)
            {
                gapWidth = Random.Range(gapWidthMinMax.x, gapWidthMinMax.y);
            }

            Vector2 chunkPosition = new Vector2(spawnedChunks[spawnedChunks.Count - 1].transform.position.x + spawnedChunks[spawnedChunks.Count - 1].GetComponent<SpriteRenderer>().bounds.size.x / 2 + chunkSize.x / 2 + gapWidth,
                cameraWorldPointY);
            chunkInstance.transform.position = chunkPosition;
        }

        spawnedChunks.Add(chunkInstance);
    }
}
