using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SwpanEnemy : MonoBehaviour
{
    public static SwpanEnemy ObjSwpanEnemy;



    public GameObject EnemyPrefab;
    public GameObject SupplerPrefab;
    public GameObject PraticalSystem;
    public GameObject PausePanel;
    public GameObject GameOverPanel;
    public GameObject PauseButton;
    public GameObject SupplyCollcetor;

    public static bool PauseBool;
    public static int EnemyHelth;
    public static int Score;
    public static int InstantiateTime = 5;


    private GameObject EnemyObj;
    private GameObject SupperObj;
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text FinalScoreText;


    private void Awake()
    {
        ObjSwpanEnemy = this;

    }
    private void Start()
    {

        Invoke("SpwanEnemy", 1f);
        Score = 0;
    }


    private void SpwanEnemy()
    {
     
        EnemyObj = Instantiate(EnemyPrefab, transform);
        EnemyHelth = Random.Range(0, 30);
       
        EnemyObj.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = EnemyHelth.ToString();
        Invoke("SpwanEnemy", InstantiateTime);
    }


    void Update()
    {
        ScoreText.text = Score.ToString();
    }

    public void GamePause()
    {
        PausePanel.SetActive(true);
        PauseButton.SetActive(false);
        PauseBool = true;
        
    }
    public void GameResume()
    {

        PausePanel.SetActive(false);
        PauseButton.SetActive(true);
        PauseBool = false;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        FinalScoreText.text= Score.ToString();
        PauseBool = true;

        GameOverPanel.SetActive(true);
    }
}
