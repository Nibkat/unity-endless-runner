using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.x < Camera.main.ViewportToWorldPoint(new Vector3(0 - 1, 0, 0)).x)
        {
            Destroy(this);
        }
    }
}
