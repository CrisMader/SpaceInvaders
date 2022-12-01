using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController3 : MonoBehaviour
{
    public GameObject bulletEnemy;
    public float timer;

    public float hpEnemy3;

    public float speed;

    public GameObject puntosParent;
    public GameObject[] puntos;
    public int punto;
    public bool special;
    public GameObject enemy;
    public GameObject bulletParent;
    public GameObject playerSeguir;

    public Vector2 dir;

    private void OnEnable()
    {
        hpEnemy3 = 14f;

        special = false;

        transform.localPosition = new Vector2(0, 2.79f);
    }
    void Start()
    {
        
        dir = Vector2.right;

        playerSeguir = GameObject.Find("Player");

        speed = 6f;

        puntosParent = GameObject.Find("Puntos");
        puntos = new GameObject[puntosParent.transform.childCount];

        for (int i = 0; i < puntos.Length; i++)
        {
            puntos[i] = puntosParent.transform.GetChild(i).gameObject;
        }
    }

    
    void Update()
    {

        if (!special)
        {
             transform.Translate(dir * speed * Time.deltaTime);
            if (transform.position.x <= -7)
            {
                dir = Vector2.right;
            }
            if (transform.position.x >= 7)
            {
                dir = Vector2.left;
            }
        }

        if (timer <= 0)
        {
            ShootLite();
        }

        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }

        if (hpEnemy3 <= 7)
        {
            special = true;
            
            if (punto < puntos.Length) {
                transform.position = Vector2.MoveTowards(transform.position, puntos[punto].transform.position, speed * Time.deltaTime);

                //print(transform.position);
                if (Vector2.Distance(transform.position, puntos[punto].transform.position) <= 0.1f)
                {
                    punto++;

                }
            }

            if(punto >= puntos.Length)
            {
                punto = 0;
            }
        }
    }

    public void ShootLite()
    {
        GameObject obj1 = Instantiate(bulletEnemy, new Vector2(enemy.transform.localPosition.x + 2f, enemy.transform.localPosition.y), Quaternion.identity);
        GameObject obj2 = Instantiate(bulletEnemy, new Vector2(enemy.transform.localPosition.x - 2f, enemy.transform.localPosition.y), Quaternion.identity);

        obj1.transform.SetParent(bulletParent.transform);
        obj1.transform.localPosition = Vector3.MoveTowards(transform.position, playerSeguir.transform.position, 2 * Time.deltaTime);

        obj2.transform.SetParent(bulletParent.transform);
        obj2.transform.localPosition = Vector3.MoveTowards(transform.position, playerSeguir.transform.position, 2 * Time.deltaTime);

        timer = Random.Range(1.0f, 3.0f);
    }

    public void TakeDmg(float dmg)
    {
        hpEnemy3 -= dmg;

        if (hpEnemy3 <= 0)
        {
            gameObject.SetActive(false);
            FindObjectOfType<PlayerController>().GetComponent<PlayerController>().enemies.Remove(gameObject);
        }
    }
}
