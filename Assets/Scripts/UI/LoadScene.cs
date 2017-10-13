using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadLevel(int buildIndex)
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("Player")[i]);
        }

        SceneManager.LoadScene(buildIndex);
    }
}
