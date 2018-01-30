using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    private GameManager gameManager;

    private int multiplier = 1;
    private float score = 0;
    private float carSpeed;
    public Text scoreText;


    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    void Update()
    {
        carSpeed = gameManager.GetSpeedScenery();
        if (true)
        {
            score += carSpeed * multiplier / 20f * Time.deltaTime; //driveSpeed
            //Debug.Log(score);
            scoreText.text = "" + Mathf.Floor(score);
        }
    }
}