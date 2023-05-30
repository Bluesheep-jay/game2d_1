using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDirPorjectile : MonoBehaviour
{
    float speed;
    Vector3 _direction;

    private void Awake()
    {
        speed = 0.7f;

    }
    void Start()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = 4 ;
        _direction =  Camera.main.ScreenToWorldPoint(pos) - gameObject.transform.position;
    }

   

    void Update()
    {
        transform.Translate(_direction* speed * Time.deltaTime);

           
            Vector3 position = transform.position;
            position += _direction * speed * Time.deltaTime;
            transform.position = position;
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector3(-9, -5));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(9, 5));

            if((transform.position.x < min.x) || (transform.position.x > max.x) || (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        
    }
}
