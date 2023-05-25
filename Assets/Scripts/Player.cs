using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public GameObject bullet;
    public Transform shootingPoint;
    GameController m_gc;
    public AudioSource aus;
    public AudioClip shootingSound;
    public GameObject explosion;
    public int lives = 3;
    public GameObject bigExplosion;
    Vector3 pos;
    Pause pauseObj;


    UImanage m_ui;
    void Start()
    {
        m_ui = FindObjectOfType<UImanage>();
        m_gc = FindObjectOfType<GameController>();
        pauseObj = FindObjectOfType<Pause>();   
    }

    void Update()
    {
        if (m_gc.IsGameOver())
        {
            return;
        }
        if (pauseObj.GetIsPaused())
        {
            return;
        }

        /*move with arrow

        float xDir = Input.GetAxisRaw("Horizontal");
        if ((xDir < 0 && transform.position.x <= -10) || (xDir > 0 && transform.position.x >= 10))
        { 
            return;
        }
        transform.position += Vector3.right * moveSpeed* xDir* Time.deltaTime;
    */

        //move with mouse
        pos = Input.mousePosition;
        pos.z = moveSpeed;
        transform.position = Camera.main.ScreenToWorldPoint(pos);

        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.Mouse0)))
        {
            shoot();
        }
    }

    public void shoot()
    {
        if (bullet && shootingPoint)
        {
            if (aus && shootingSound)
            {
                aus.PlayOneShot(shootingSound);

            }
            Instantiate(bullet, shootingPoint.position, Quaternion.identity);
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
           if (explosion)
            {
                Instantiate(explosion, collision.transform.position, Quaternion.identity);
            }
            m_gc.SetGameOverState();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            lives -= 1;
            m_ui.ShowPlayerLives("" + lives);
            if (lives > 0)
            {
                Instantiate(explosion, collision.transform.position, Quaternion.identity);
            }

            if (lives <= 0)
            {
                 
                m_gc.SetGameOverState();
                Destroy(gameObject);
                Instantiate(bigExplosion, collision.transform.position, Quaternion.identity);
            }
        }
        if (collision.CompareTag("EnemyProjectile"))
        {
            Destroy(collision.gameObject);
            lives -= 1;
            m_ui.ShowPlayerLives("" + lives);
            if (lives > 0)
            {
                Instantiate(explosion, collision.transform.position, Quaternion.identity);
            }

            if (lives <= 0)
            {
                m_gc.SetGameOverState();
                Destroy(gameObject);
                Instantiate(bigExplosion, collision.transform.position, Quaternion.identity);
            }
        }
    }
}
