using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    private PlayerMovement player;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void RespawnPlayer()
    {
        Debug.Log("Megaman Respwaned");
        player.transform.position = currentCheckpoint.transform.position;
    }

    public void LoadLevel(string name)
    {

        SceneManager.LoadScene(name);
    }

    public void EndGame()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }
}
