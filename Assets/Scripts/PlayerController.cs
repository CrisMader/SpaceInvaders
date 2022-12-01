using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    public float speed;
    public float cooldown;
    public float hpPlayer;
    public float hpPlayerMax;

    public GameObject bullets;
    public GameObject specialBullets;

    public GameObject gameOver;
    public GameObject pause;

    public Slider valueHp;

    public List<GameObject> enemies;

    public GameObject enemiesParent;

    public GameObject pLayer;


    void OnEnable()
    {
        enemies.RemoveRange(0,enemies.Count);
        hpPlayer = 5f;
        valueHp.value = hpPlayer;

        transform.position = new Vector2(0.05f, -3.69f);

        enemiesParent = GameObject.Find("Enemies");
        for (int i = 0; i < enemiesParent.transform.childCount; i++)
        {
            enemies.Add(enemiesParent.transform.GetChild(i).gameObject);
            enemies[i].SetActive(true);
        }
    }
    void Start()
    {
        gameOver = FindObjectOfType<GameManager>().GetComponent<GameManager>().gameOver;
        pause = FindObjectOfType<GameManager>().GetComponent<GameManager>().canvasPausa;

        enemiesParent = GameObject.Find("Enemies");

        valueHp.maxValue = 5;  
    }

    

    
    void Update()
    {
        Movement();

        if (cooldown >= 0)
        {
           cooldown -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && cooldown <= 0f)
        {
           Shoot();
        }
        if (enemies.Count <= 0)
        {
           FindObjectOfType<GameManager>().GetComponent<GameManager>().nivel1.SetActive(false);
           FindObjectOfType<GameManager>().GetComponent<GameManager>().nivel2.SetActive(false);
           FindObjectOfType<GameManager>().GetComponent<GameManager>().nivel3.SetActive(false);
           FindObjectOfType<GameManager>().GetComponent<GameManager>().nivel4.SetActive(false);
           FindObjectOfType<GameManager>().GetComponent<GameManager>().player.SetActive(false);
           FindObjectOfType<GameManager>().GetComponent<GameManager>().selectLevel.SetActive(true);

           for (int i = 0; i < bullets.transform.childCount; i++)
           {
               Destroy(bullets.transform.GetChild(i).gameObject);
           }
           for (int i = 0; i < specialBullets.transform.childCount; i++)
           {
               Destroy(specialBullets.transform.GetChild(i).gameObject);
           }
            FindObjectOfType<GameManager>().GetComponent<GameManager>().ActivarNivel();
        }
        


        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            Pausa();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            QuitarPausa();
        }


       
        
    }

    public void Movement()
    {
        float h = Input.GetAxisRaw("Horizontal");

        transform.Translate(new Vector2(h, 0) * speed * Time.deltaTime);
    }

    public void Shoot()
    {
        cooldown = 0.4f;
        GameObject obj = Instantiate(bullet, transform.position, Quaternion.identity);
        obj.GetComponent<BulletController>().isPlayer = true;
        obj.transform.SetParent(specialBullets.transform);
    }

    public void TakeDmg(float dmg)
    {
        hpPlayer -= dmg;
        valueHp.value = hpPlayer;
        if (hpPlayer <= 0)
        {
            gameObject.SetActive(false);
            gameOver.SetActive(true);
            enemies.Remove(gameObject);
            Time.timeScale = 0;
        }
    }
    public void Pausa()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
    }
    public void QuitarPausa()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }
    /*public void Menu()
    {
        SceneManager.LoadScene(1);
    }

    /*public void Registrar()
    {
        if (FindObjectOfType<GameManager>().GetComponent<GameManager>().level1 == true)
        {

        }
    }*/
}
