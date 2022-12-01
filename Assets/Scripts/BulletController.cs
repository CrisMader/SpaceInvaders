using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public bool isPlayer;
    void Start()
    {
        Destroy(gameObject, 2);
    }

    
    void Update()
    {
        if (isPlayer)
        {
            transform.Translate(Vector2.up * 5 * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * 8 * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && isPlayer)
        {
            collision.GetComponent<EnemyController>().TakeDmg(1);
            Destroy(gameObject);
        }
        if (collision.tag == "Enemy2" && isPlayer)
        {
            collision.GetComponent<EnemyController2>().TakeDmg(1);
            Destroy(gameObject);
        }
        if (collision.tag == "Enemy3" && isPlayer)
        {
            collision.GetComponent<EnemyController3>().TakeDmg(1);
            Destroy(gameObject);
        }
        if (collision.tag == "Enemy4" && isPlayer)
        {
            collision.GetComponent<EnemyController4>().TakeDmg(1);
            Destroy(gameObject);
        }
        if (collision.tag == "Player" && !isPlayer)
        {
            collision.GetComponent<PlayerController>().TakeDmg(1);
            Destroy(gameObject);
        }
    }
}
