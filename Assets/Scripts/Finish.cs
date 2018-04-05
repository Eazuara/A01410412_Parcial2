﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public void LoadNextLevel()
    {

        

        //  Load the next scene in the build order
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.CompareTag ("Megaman"))
        {
            Application.LoadLevel("Lvl 2");
        }
    }
}