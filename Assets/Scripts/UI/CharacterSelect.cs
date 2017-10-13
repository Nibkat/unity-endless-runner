using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject[] players;

    private int playerIndex = 0;

    [SerializeField]
    private Image playerImage;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerIndex++;
            SwitchPlayer();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            playerIndex--;
            SwitchPlayer();
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            PlayerSelected();
        }
    }

    private void SwitchPlayer()
    {
        if (playerIndex == players.Length)
        {
            playerIndex = 0;
        }
        else if (playerIndex < 0)
        {
            playerIndex = players.Length - 1;
        }

        playerImage.sprite = players[playerIndex].GetComponent<SpriteRenderer>().sprite;
        playerImage.SetNativeSize();
    }

    private void PlayerSelected()
    {
        DontDestroyOnLoad(Instantiate(players[playerIndex]));

        SceneManager.LoadScene(1);
    }
}
