using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    private GameObject gameManagerObject;
    GameManager gameManager;


    private int multiplier = 1;
    public int jumpScore = 100;
    public float score = 0;
    private float currCarSpeed;
    Text text;

    public Text combo;
    public Text comboTimer;
    public GameObject panelObject;

    bool hideCombo = false;

    float time = 400;

    void Awake()
    {
        text = GetComponent<Text>();
        score = 0;

        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();

        //ragdollFallingObject = GameObject.FindGameObjectWithTag("Player");
        //ragdollFalling = ragdollFallingObject.GetComponent<RagdollFalling>();
    }

    void Update()
    {
        if(true)//ragdollFalling.hitTheGround == false)
        {
            currCarSpeed = gameManager.GetSpeedCars();
            score = score + currCarSpeed * Time.deltaTime;

            //Combo on jumping to another car
            

            text.text = "Score: " + (int)score;
        }

        if (hideCombo == true)
        {
            time--;
            if (time <= 0)
            {
                HideCombo();
            }
        }
    }

    public void AddScoreOnCarJump()
    {
        score = score + jumpScore;
        multiplier++;
        text.text = "Score: " + (int)score;

    } 

    public void HideCombo()
    {

    }

}