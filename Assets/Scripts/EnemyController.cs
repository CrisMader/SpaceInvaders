using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float hp;
    public Vector2 dir; //dir de dirección
    public GameObject enemiesParent;
    public GameObject bulletEnemy;
    public GameObject emparentBullet;
    public float timer;

    private void OnEnable()
    {
        hp = 1f;
    }
    void Start()
    {
        dir = Vector2.right;
        enemiesParent = GameObject.Find("Enemies");
        timer = Random.Range(1.0f, 6.0f);
    }

    
    void Update()
    {
        transform.Translate(dir * 6 * Time.deltaTime);

        if (transform.position.x <= -8)
        {
            CambiarDireccion(Vector2.right);
        }
        if (transform.position.x >= 7)
        {
            CambiarDireccion(Vector2.left);
        }

        if (timer <= 0)
        {
            Shoot();
        }

        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void CambiarDireccion(Vector2 direccion)
    {
        for (int i = 0; i < enemiesParent.transform.childCount; i++)
        {
            enemiesParent.transform.GetChild(i).GetComponent<EnemyController>().dir = direccion;
        }
    }

    public void TakeDmg(float dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            gameObject.SetActive(false);
            FindObjectOfType<PlayerController>().GetComponent<PlayerController>().enemies.Remove(gameObject);
        }
    }

    public void Shoot()
    {
        GameObject obj = Instantiate(bulletEnemy, transform.position, Quaternion.identity);
        obj.GetComponent<BulletController>().isPlayer = false;
        obj.transform.SetParent(emparentBullet.transform);
        
        timer = Random.Range(1.0f, 6.0f);
    }
}
