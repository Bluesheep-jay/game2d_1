using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D m_rb;
    GameController m_gc;
    float count = 0;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = Vector2.down * moveSpeed;
        if(m_gc.level == 2)
        {

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            //m_gc.SetGameOverState() ;
            Destroy(gameObject);
        }
        if (collision.CompareTag("bullet")){
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
    }
}
