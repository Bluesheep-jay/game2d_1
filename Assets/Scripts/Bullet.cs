using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D m_rb;
    public float speed;

    GameController m_gc;
    AudioSource aus;
    public AudioClip boom;
    

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
        aus = FindObjectOfType<AudioSource>();
    }
      
    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = Vector3.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy")) {
            if(aus && boom)
            {
                aus.PlayOneShot(boom);
            }
              Destroy(gameObject);

        }
        if (collision.CompareTag("SceneTopLimitted"))
        {
            Destroy(gameObject);
        }
    }
}
