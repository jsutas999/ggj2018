using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public SegmentManager RoadSegmentManager;
    public SegmentManager TerrainSegmentManager;
    public SegmentManager CarSegmentManager;
    public SceneFade sceneFade;

    public ScoreManager scoreManager;

    public GameObject gameOverMenu;

    Scene currScene;

    [Range(0f, 2.0f)]
    public float timeScale = 1f;
    bool gameover = false;
    float cars, scen;

    private void Start()
    {
        currScene = SceneManager.GetActiveScene();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        if (gameover && timeScale > 0)
        {
            timeScale -= 0.01f;
            if (timeScale < 0)
                timeScale = 0;
            SetSpeedScenery(scen * timeScale);
            SetSpeedCars(cars * timeScale);
        }
    }
    // Depricated
    public void SetSpeed(float speed)
    {
        RoadSegmentManager.SetSpeed(speed);
        TerrainSegmentManager.SetSpeed(speed);
        CarSegmentManager.SetSpeed(speed);
    }
    /*void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 300, 20), "" + Input.gyro.attitude);
        GUI.Label(new Rect(20, 40, 300, 20), "Update: " + Mathf.Floor(1 /Time.deltaTime));
        GUI.Label(new Rect(20, 60, 300, 20), "FixedUpdate: " + Mathf.Floor(1/Time.fixedDeltaTime));
    }*/
    // Depricated
    public float GetSpeed() {
        return RoadSegmentManager.GetSpeed();
    }

    public float GetSpeedScenery() {
        return RoadSegmentManager.GetSpeed();
    }

    public float GetSpeedCars() {
        return CarSegmentManager.GetSpeed();
    }

    public void SetSpeedScenery(float speed) {
        RoadSegmentManager.SetSpeed(speed);
        TerrainSegmentManager.SetSpeed(speed);
    }

    public void SetSpeedCars(float speed) {
        CarSegmentManager.SetSpeed(speed);
    }

    public void RemoveCarFromSegment(GameObject car) {
        CarSegmentManager.RemoveFromManager(car);
        //scoreManager.AddScoreOnCarJump();
    }

    public void AddCarToSegment(GameObject car) {
        CarSegmentManager.AddToSegment(car);
    }
    public void GameOver() {
        gameover = true;
        scoreManager.GameOver();
        cars = GetSpeedCars();
        scen = GetSpeedScenery();
        Invoke("GameOverMenu", 1);
    }
    public void GameOverMenu() {
        gameOverMenu.gameObject.SetActive(true);
    }
    public void Restart() {
        sceneFade.FadeOut();
        StartCoroutine(WaitFade(true));
    }
    public void BackToMenu() {
        sceneFade.FadeOut();
        StartCoroutine(WaitFade(false));
    }
    IEnumerator WaitFade(bool restart) {
        if (restart) {
            for (float i = 0; i <= 1; i += Time.deltaTime)
                yield return null;
            SceneManager.LoadScene(currScene.name, LoadSceneMode.Single);
        }
        else {
            for (float i = 0; i <= 1; i += Time.deltaTime)
                yield return null;
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
