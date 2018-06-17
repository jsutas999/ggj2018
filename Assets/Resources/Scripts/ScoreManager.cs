using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {
    private GameManager gameManager;

    private int multiplier = 0;
    private float score = 0;
    private float carSpeed;
    public Text scoreText, multText, coinText;
    public Image multImage;
    public float time = 3;
    private float timer;
    private bool airtime = false;
    private int currentCoins = 0;

    void Start() {
        gameManager = GetComponent<GameManager>();
        timer = time;
    }

    void Update() {
        carSpeed = gameManager.GetSpeedScenery();
        score += carSpeed * multiplier / 20f * Time.deltaTime; //driveSpeed
        if (multiplier > 0 && !airtime)
            timer -= Time.deltaTime;
        if (timer <= 0)
            multiplier = 0;

        if (true) { //Update UI
            scoreText.text = "" + Mathf.Floor(score);
            multText.text = "" + multiplier;
            multImage.fillAmount = timer / time;
            coinText.text = "" + currentCoins;
        }
    }

    public void GameOver() {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + currentCoins);
        Debug.Log("Current total coins: " + PlayerPrefs.GetInt("Coins"));
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