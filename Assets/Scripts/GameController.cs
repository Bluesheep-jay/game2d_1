using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime;
    float m_spawnTime;
    int m_score;
    bool m_isGameOver;
    UImanage m_ui;

    // choose characters;
    public GameObject[] PlayerPrefabs;
    int characterIndex;

    // Start is called before the first frame update
    void Start()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        Instantiate(PlayerPrefabs[characterIndex], new Vector2(0, -3), Quaternion.identity );  

        m_spawnTime = 0;
        m_ui = FindObjectOfType<UImanage>();
        m_ui.SetScoreText("Score: " + m_score);

    }

    void Update()
    {
        if (m_isGameOver)
        {
            m_spawnTime = 0;
            m_ui.ShowGameOverPanel(true);
            return;
        }
        m_spawnTime -= Time.deltaTime;

       

        if (m_spawnTime <=0)
        {
            SpawnEnemy();
            m_spawnTime = spawnTime;
        }

    }

    public void SpawnEnemy()
    {
        float randXpos = Random.Range(-9f, 9f);
        Vector2 spawnPos = new Vector2(randXpos, 6.5f);
        if (enemy)
        {  
            Instantiate(enemy, spawnPos, Quaternion.identity);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("level_01");
    }
    public void SetScore(int val)
    {
        m_score = val;
    }
    public int GetScore()
    {
        return m_score;
    }

 
    
    public void ScoreIncre()
    {
        if (m_isGameOver)
        {
            return;
        }
        m_score += 10;
        
        m_ui.SetScoreText("Score: " + m_score);
    }
       public void SetGameOverState()
    {
        m_isGameOver = true;
    }
    public bool IsGameOver()
    {
        return m_isGameOver;
    }
    
}
