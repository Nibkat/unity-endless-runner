using System.Collections;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private GameObject endGameUI;

    void OnPlayerDied()
    {
        StartCoroutine(WaitForEndGameUI());
    }

    IEnumerator WaitForEndGameUI()
    {
        yield return new WaitForSeconds(5);
        endGameUI.SetActive(true);
    }
}
