using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    public float cooldown;
    public GameObject attack1;
    public GameObject attack2;

    public GameObject bulletEnemy;
    public float timer;

    public float hpEnemy2;

    public bool isAttacking;

    public GameObject enemy;
    
    public GameObject emparentEspcial;

    public Vector2 dir;

    private void OnEnable()
    {
        hpEnemy2 = 20f;
        isAttacking = false;
        transform.localPosition = new Vector2(0, 2.8f);
    }
    void Start()
    {
       
        dir = Vector2.right;

        timer = Random.Range(1.0f, 6.0f);
    }

    
    void Update()
    {
        if (!isAttacking)
        {
            transform.Translate(dir * 6 * Time.deltaTime);
            if (transform.position.x <= -7)
            {
                dir = Vector2.left;
            }
            if (transform.position.x >= 7)
            {
                dir = Vector2.right;
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

        cooldown += Time.deltaTime;

        if (cooldown >= 6.5f)
        {
            StartCoroutine(Shoot());
            cooldown = 0;
        }
    }

    public IEnumerator Shoot()
    {
        isAttacking = true;
        GameObject obj1 = Instantiate(attack1, new Vector2(enemy.transform.position.x + 0.15f, 0.75f), Quaternion.identity);
        obj1.transform.SetParent(emparentEspcial.transform);
        attack1.transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(10, 10, 1), 1 * Time.deltaTime);

        yield return new WaitForSeconds(2f);

        Destroy(obj1);
        GameObject obj2 = Instantiate(attack2, new Vector2(enemy.transform.position.x + 0.15f, -2.5f), Quaternion.identity);
        obj2.transform.SetParent(emparentEspcial.transform);

        yield return new WaitForSeconds(3f);

        Destroy(obj2);
        isAttacking = false;

        yield return null;
    }
    public void TakeDmg(float dmg)
    {
        hpEnemy2 -= dmg;

        if (hpEnemy2 <= 0)
        {
            enemy.SetActive(false);
            FindObjectOfType<PlayerController>().GetComponent<PlayerController>().enemies.Remove(gameObject);
        }
    }
}
