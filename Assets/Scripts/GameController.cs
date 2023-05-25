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
    public int level;
    Player levelUp;

    public string nameScene = "level_02";
    public float delaySecond = 2;
    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UImanage>();
        m_ui.SetScoreText("Score: " + m_score);
        levelUp = FindObjectOfType<Player>();
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
        // level up;
        if(m_score >= 10)
            spawnTime = 1.4f;      
        if(m_score >= 15)
            spawnTime = 1.2f;   
        if(m_score >= 20) {
            level = 2;
            spawnTime = 1f;
        }

        if (m_score >= 30)
            spawnTime = 0.8f;

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

    IEnumerable LoadAfterDelay()
    {
        Debug.Log("laod");
        yield return new WaitForSeconds(delaySecond);
    }
    
    public void ScoreIncre()
    {
        if (m_isGameOver)
        {
            return;
        }
        m_score++;
        if(m_score == 20)
        {
            SceneManager.LoadScene(nameScene);

        }

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
