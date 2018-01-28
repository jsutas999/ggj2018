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
<<<<<<< HEAD
    public Text combo;
    public Text comboTimer;
    public GameObject panelObject;

    float time = 400;
=======
>>>>>>> 3f342a640f69e2731eb2330574dbe5e9b5a92fe3

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
<<<<<<< HEAD

        if (hideCombo == true)
        {
            time--;
            if (time <= 0)
            {
                HideCombo();
            }
        }
=======
>>>>>>> 3f342a640f69e2731eb2330574dbe5e9b5a92fe3
    }

    public void AddScoreOnCarJump()
    {
        score = score + jumpScore;
        multiplier++;
        text.text = "Score: " + (int)score;

    } 


}