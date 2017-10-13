using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        Vector3 cameraPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);

        transform.position = cameraPosition;
    }
}
