using System.Linq;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField]
    private Transform[] backgroundTransforms;

    [SerializeField]
    private float backgroundWidth = 12.8f;

    private Rigidbody2D playerRigidBody2D;

    private void Awake()
    {
        playerRigidBody2D = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * playerRigidBody2D.velocity.x * 0.1f * Time.deltaTime * 100);
    }

    private void LateUpdate()
    {
        for (int i = 0; i < backgroundTransforms.Length; i++)
        {
            if (backgroundTransforms[i].position.x < Camera.main.ViewportToWorldPoint(new Vector3(0 - 1, 0, 0)).x)
            {
                backgroundTransforms[i].position = new Vector3
                    (backgroundTransforms[backgroundTransforms.Length - 1].position.x + backgroundWidth,
                    backgroundTransforms[backgroundTransforms.Length - 1].position.y,
                    backgroundTransforms[backgroundTransforms.Length - 1].position.z);

                backgroundTransforms = backgroundTransforms.OrderBy(backgroundTransforms => backgroundTransforms.position.x).ToArray();
            }
        }
    }
}
