using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverAndRetry : MonoBehaviour {

    Animator animator;
    bool showScreen = false;

    public Scene currScene;

    private void Start()
    {
        currScene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && showScreen == true)
        {
            SceneManager.LoadScene(currScene.name, LoadSceneMode.Single);
        }
    }

    public void GameOver()
    {
        Invoke("LaunchScreen", 1);
    }

    void LaunchScreen()
    {
        showScreen = true;
        animator = GameObject.Find("DeathScreen").GetComponent<Animator>();
        animator.SetBool("Died", showScreen);
    }
}
