﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene("finalGame", LoadSceneMode.Single);
    }
}
