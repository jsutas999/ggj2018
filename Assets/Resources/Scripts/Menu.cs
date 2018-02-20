using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public GameObject StoreMenu;
    public GameObject SettingsMenu;
    public GameObject CustomMenu;

    private void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("Coins"));
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Backspace)) {
            if (StoreMenu.activeSelf || SettingsMenu.activeSelf || CustomMenu.activeSelf)
                BackToMenu();
            else
                QuitGame();
        }
    }
    public void StartGame() {
        SceneManager.LoadScene("finalGame", LoadSceneMode.Single);
    }
    public void QuitGame() {
        Application.Quit();
    }
    public void Store() {
        StoreMenu.SetActive(true);
    }
    public void Settings()
    {
        SettingsMenu.SetActive(true);
    }
    public void Customize()
    {
        CustomMenu.SetActive(true);
    }
    public void BackToMenu() {
        StoreMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        CustomMenu.SetActive(false);
    }
}
