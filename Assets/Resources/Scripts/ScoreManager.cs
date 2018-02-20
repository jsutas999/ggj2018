using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreManager : MonoBehaviour {
    private GameManager gameManager;

    private int multiplier = 1;
    private float score = 0;
    private float carSpeed;
    public Text scoreText, multText, coinText;
    public Image multImage;
    public float time = 3;
    private float timer;
    private bool airtime = false;
    private int currentCoins = 0;
    public GameObject DeathScreen;

    bool showScreen = false;

    public Scene currScene;

    void Start() {
        gameManager = GetComponent<GameManager>();
        timer = time;
        currScene = SceneManager.GetActiveScene();
    }

    void Update() {
        carSpeed = gameManager.GetSpeedScenery();
        score += carSpeed * multiplier / 20f * Time.deltaTime; //driveSpeed
        if (multiplier > 1 && !airtime)
            timer -= Time.deltaTime;
        if (timer <= 0)
            multiplier = 1;

        if (true) { //Update UI
            scoreText.text = "" + Mathf.Floor(score);
            multText.text = "x" + multiplier;
            multImage.fillAmount = timer / time;
            coinText.text = "" + currentCoins;
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1")) && showScreen == true)
        {
            SceneManager.LoadScene(currScene.name, LoadSceneMode.Single);
        }
    }
    public void GameOver() {
        Invoke("LaunchScreen", 1);
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + currentCoins);
    }

    void LaunchScreen() {
        //Debug.Log("launch screen");
        showScreen = true;
        DeathScreen.GetComponent<Animator>().SetBool("Died", showScreen); ;
    }
    public void CollectCoin(int coin) {
        currentCoins += coin;
    }
    public void EnterCar() {
        airtime = false;
        timer = time;
        float points = 10f * multiplier;
        score += points;
        multiplier++;
        //Debug.Log("Enter Car! Add points: " + points);
    }
    public void HitAnimal()
    {
        float points = 100 * multiplier;
        score += points;
        //Debug.Log("Hit Animal! Add points: " + points);
    }
    public void CrashCar() {
        airtime = true;
        float points = 5;
        score += points;
        //Debug.Log("Crash! Add points: " + points);
    }
}