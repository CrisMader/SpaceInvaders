using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController4 : MonoBehaviour
{
    public float hpEnemy4;
    public Slider hpEnemy;
    public float speed;

    public float cooldown;

    public GameObject enemy;
    public GameObject playerSeguir;

    public bool faseDos;
    public bool faseTres;
    public bool isAttacking;

    public GameObject attack1;
    public GameObject attack2;

    public GameObject emparentEspecial;

    public GameObject bulletEnemy;

    public GameObject Bullets;
    public float timer;

    public Vector2 dir;

    private void OnEnable()
    {
        hpEnemy4 = 40f;
        hpEnemy.value = hpEnemy4;
        faseTres = false;
        
    }
    void Start()
    {
        dir = Vector2.right;
        speed = 6f;

        faseDos = false;
        faseTres = false;

        hpEnemy.maxValue = 40f;
        hpEnemy.value = hpEnemy4;
    }

    void Update()
    {
        if (!faseTres)
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
 
        if (hpEnemy4 >= 30 && hpEnemy4 <= 40)
        {
            hpEnemy.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<Image>().color = new Color(0f, 0.3028021f, 1f, 1f);
            if (timer <= 0)
            {
                Shoot();
            }

            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            return;
        }


        if (hpEnemy4 >= 20  && hpEnemy4 < 30 && !faseTres && !isAttacking)
        {
            faseDos = true;
            hpEnemy.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<Image>().color = new Color(1f,1f,0f,1f);
            if (timer <= 0)
            {
                    Shoot2();
            }

            if (timer >= 0)
            {
                    timer -= Time.deltaTime;
            }
            return;
        }

        /*if (hpEnemy4 <= 21)
        {
            isAttacking = true;
        }*/

        if (hpEnemy4 < 20 /*&& !faseDos && isAttacking*/)
        {
            faseDos = false;
            hpEnemy.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<Image>().color = new Color(1f, 0.1535172f, 0f, 1f);
            cooldown += Time.deltaTime;

            if (cooldown >= 6.5f)
            {
                StartCoroutine(Shoot3());
                cooldown = 0;
            }
            return;
        }

        


    }

    public void TakeDmg(float dmg)
    {
        hpEnemy4 -= dmg;
        hpEnemy.value = hpEnemy4;
        if (hpEnemy4 <= 0)
        {
            gameObject.SetActive(false);
            FindObjectOfType<PlayerController>().GetComponent<PlayerController>().enemies.Remove(gameObject);
        }
    }

    public void Shoot()
    {
        GameObject obj = Instantiate(bulletEnemy, transform.position, Quaternion.identity);
        obj.GetComponent<BulletController>().isPlayer = false;

        timer = Random.Range(1.0f, 2.0f);
    }

    public void Shoot2()
    {
        GameObject obj1 = Instantiate(bulletEnemy, new Vector2(enemy.transform.localPosition.x + 2f, enemy.transform.localPosition.y), Quaternion.identity);
        GameObject obj2 = Instantiate(bulletEnemy, new Vector2(enemy.transform.localPosition.x - 2f, enemy.transform.localPosition.y), Quaternion.identity);

        obj1.transform.SetParent(Bullets.transform);
        obj1.transform.localPosition = Vector3.MoveTowards(transform.position, playerSeguir.transform.position, 2 * Time.deltaTime);

        obj2.transform.SetParent(Bullets.transform);
        obj2.transform.localPosition = Vector3.MoveTowards(transform.position, playerSeguir.transform.position, 2 * Time.deltaTime);

        timer = Random.Range(1.0f, 3.0f);

    }
    public IEnumerator Shoot3()
    {
        faseTres = true;
        GameObject obj1 = Instantiate(attack1, new Vector2(enemy.transform.position.x, 0.75f), Quaternion.identity);
        obj1.transform.SetParent(emparentEspecial.transform);
        attack1.transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(10, 10, 1), 1 * Time.deltaTime);

        yield return new WaitForSeconds(2f);

        Destroy(obj1);
        GameObject obj2 = Instantiate(attack2, new Vector2(enemy.transform.position.x, -2.5f), Quaternion.identity);
        obj2.transform.SetParent(emparentEspecial.transform);

        yield return new WaitForSeconds(3f);

        Destroy(obj2);
        faseTres = false;

        yield return null;
    }
}
