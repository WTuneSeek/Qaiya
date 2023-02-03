using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        LoadSideViewLevel();
    }

    void LoadSideViewLevel()
    {
        // Load the level named "HighScore".
        SceneManager.LoadScene("FacilitySideView");
    }
}
