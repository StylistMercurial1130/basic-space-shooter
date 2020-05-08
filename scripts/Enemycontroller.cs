using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontroller : MonoBehaviour
{
    public float EnemyMovespeed = 5f;
    
    void Update()
    {
        moveEnemy();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "bullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void moveEnemy()
    {
        transform.Translate(Vector2.down * Time.deltaTime * EnemyMovespeed, Space.World);
        if (transform.position.y < -(Camera.main.orthographicSize))
            Destroy(gameObject);
    }

}
