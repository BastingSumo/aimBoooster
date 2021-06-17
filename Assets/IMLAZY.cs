using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class IMLAZY : MonoBehaviour
{
    public static IMLAZY instance;
    
    [SerializeField] Text ScoreText;
    [SerializeField] Text HighScoreText;
    [SerializeField] Text LivesText;

    [SerializeField] int HighScore;
    [SerializeField] int Score;

    [SerializeField] GameObject TargetPrefab;
    [SerializeField] GameObject TargetPrefab2;
    [SerializeField] GameObject TargetPrefab3;
    [SerializeField] GameObject TargetPrefab4;
    [SerializeField] float SpawnRate = .1f;

    public static float targetMoveSpeed = 1;

    [SerializeField] TextMeshProUGUI timeDisplay;

    float timer;

    float TargetDistance = 5;

    int counter = 0;

    [SerializeField] int Lives = 3;

    public AudioSource audioSource;
    public AudioClip bad;
    public AudioClip good;

    bool isPaused = false;

    public float GetSpawnRate { get => SpawnRate;  }
    public int lives { get => Lives; set => Lives = value; }

    private void Awake()
    {
        if (instance != this) Destroy(instance);
        instance = this;
    }
    private void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
    }
    void Update()
    {
        Spawn();
        Shoot();
        UpdateScore();
        Restart();
        DisplayTime();
        Pause();
    }
    void DisplayTime() => timeDisplay.text = "Time: " + Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1)
        {
            Time.timeScale = 0f;
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        { 
            Time.timeScale = 1;
            isPaused = false;
        }
    }
    void Restart()
    {
        if (Lives < 0) SceneManager.LoadScene(0);

    }
    void Spawn()
    {
        timer += 1 * Time.deltaTime;
        if (timer >= SpawnRate)
        {
            float random = Random.Range(0, 100);
            if (random < 25)
            {
                Instantiate(TargetPrefab, new Vector3(Random.Range(-10, 10), Random.Range(6, 6), Random.Range(5, TargetDistance)), Quaternion.identity);
            }
            else if (random < 50)
            {

                Instantiate(TargetPrefab2, new Vector3(Random.Range(-10, 10), Random.Range(6, 6), Random.Range(5, TargetDistance)), Quaternion.identity);
            }
            else if (random < 75)
            {
                Instantiate(TargetPrefab3, new Vector3(Random.Range(-10, 10), Random.Range(6, 6), Random.Range(5, TargetDistance)), Quaternion.identity);
            }
            else if (random < 100)
            {
                Instantiate(TargetPrefab4, new Vector3(Random.Range(-10, 10), Random.Range(6, 6), Random.Range(5, TargetDistance)), Quaternion.identity);
            }
            timer = 0;
        }
    }
    void UpdateScore()
    {
        ScoreText.text = " Score : " + Score.ToString();
        HighScoreText.text = " HighScore : " + HighScore.ToString();
        LivesText.text = " Lives : " + Lives.ToString();
        if (Score > HighScore)
        {
            HighScore = Score;
        }
        PlayerPrefs.SetInt("HighScore", HighScore);
        PlayerPrefs.Save();
    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && isPaused == false)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity))
            {
                Destroy(hit.collider.gameObject);

                SpawnRate -= .001f;
                targetMoveSpeed += .001f;
                if (TargetDistance < 10)
                {
                    TargetDistance += .5f;
                }
                audioSource.PlayOneShot(good);
                counter++;
                Score++;
            }
        }
    }
}
