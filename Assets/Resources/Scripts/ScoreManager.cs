using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{

    private GameObject gameManagerObject;
    GameManager gameManager;
    public GameObject ragdollFallingObject;
    RagdollFalling ragdollFalling;


    private int multiplier = 0;
    private int currMultiplier;
    private bool hideCombo = false;


    public int jumpScore = 100;
    public float score = 0;
    private float currCarSpeed;
    Text text;
    public Text combo;
    public Text comboTimer;
    public GameObject panelObject;

    float time = 400;

    void Awake()
    {
        text = GetComponent<Text>();
        score = 0;

        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();

        ragdollFalling = ragdollFallingObject.GetComponent<RagdollFalling>();

        panelObject.SetActive(false);

    }

    void Update()
    {
        if(ragdollFalling.hitTheGround == false)
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
        multiplier++;
        currMultiplier = multiplier;

        score = score + jumpScore*multiplier;

        if (multiplier >= 2)
        {
            panelObject.SetActive(true);
            combo.text = "Combo: x" + multiplier;
            hideCombo = true;
        }
    }
    
    void HideCombo()
    {
        multiplier = 0;
        hideCombo = false;
        time = 400;
        panelObject.SetActive(false);
    }
}