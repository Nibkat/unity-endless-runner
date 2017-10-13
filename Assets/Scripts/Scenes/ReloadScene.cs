using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    GameObject player;
    GameObject newPlayer;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        newPlayer = Instantiate(GameObject.FindWithTag("Player"));
        newPlayer.SetActive(false);
    }

    public void RestartScene()
    {
        Destroy(player);
        newPlayer.SetActive(true);

        DontDestroyOnLoad(newPlayer);

        SceneManager.LoadScene(1);
    }
}
