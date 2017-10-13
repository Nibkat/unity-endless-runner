using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AnyKey : MonoBehaviour
{
    public GameObject PlayerMode;
    public GameObject CanvasA;

    enum Players { Mario, Link, Pikachu, ShinChan, Luigi, Sonic};



    private Dictionary<Players, GameObject> playersDictionary;

    private void Start()
    {
        playersDictionary.Add(Players.Link, Resources.Load("Link") as GameObject);
        playersDictionary.Add(Players.Mario, Resources.Load("Mario") as GameObject);
        playersDictionary.Add(Players.ShinChan, Resources.Load("Shin-Chan") as GameObject);

        PlayerMode.gameObject.SetActive(false);   
    }


    private void Update()
    {
        /*if (Input.anyKeyDown)
        {
            SceneManager.LoadSceneAsync(1);
        }*/
    }
    public void ShowUIPlayer1()
    {
        PlayerMode.gameObject.SetActive(true);
        CanvasA.gameObject.SetActive(false);
       
    }
    public void CharacterSelection()
    {
    
    }


}

