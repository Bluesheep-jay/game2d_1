using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3_2 : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D m_rb;
    GameController m_gc;
    float count = 0;
    public GameObject explosion;

    Player m_pl;
    UImanage m_ui;
    // Start is called before the first frame update    
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
        m_pl = FindObjectOfType<Player>();

        m_ui = FindObjectOfType<UImanage>();
    }
     
    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = Vector2.down * moveSpeed;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            //m_gc.SetGameOverState() ;
            Destroy(gameObject);
        }
        if (collision.CompareTag("TankBullet"))
        {
            count++;

            if (count == 3)
            {
                if (explosion)
                {
                    Instantiate(explosion, collision.transform.position, Quaternion.identity);
                }
                m_gc.ScoreIncre();

                Destroy(gameObject);
                count = 0;
            }

        }
        if (collision.CompareTag("AssassinBullet"))
        {
            count++;

            if (count == 2)
            {
                if (explosion)
                {
                    Instantiate(explosion, collision.transform.position, Quaternion.identity);
                }
                m_gc.ScoreIncre();

                Destroy(gameObject);
                count = 0;
            }
        }
        if (collision.CompareTag("DeathZone"))
        {
            m_pl.livesDecre();
            if (m_pl.lives <= 0)
            {
                m_pl.lives = 0;
                m_gc.SetGameOverState();
            }
            m_ui.ShowPlayerLives("" + m_pl.lives);

        }
    }
}
