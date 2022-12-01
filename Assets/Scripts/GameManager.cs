using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject animMeteorito;
    public GameObject menu;
    public GameObject selectLevel;
    public float cooldown;

    public GameObject emparentEspecial;

    public Button[] levels;

    public List<GameObject> aEspeciales;

    public Sprite ole2, ole3, ole4;
    public GameObject text2, text3, text4;
    public GameObject tex2, tex3, tex4;

    public GameObject gameOver;
    public GameObject canvasPausa;

    public GameObject player;

    public GameObject nivel1, nivel2, nivel3, nivel4;

    public bool level1, level2, level3, level4;
 

    void Awake()
    {
        menu.SetActive(true);
        selectLevel.SetActive(false);
        nivel1.SetActive(false);
        nivel2.SetActive(false);
        nivel3.SetActive(false);
        nivel4.SetActive(false);
    }
    void Start()
    {
        menu.SetActive(true);
    }

    

    void Update()
    {

        if (selectLevel.activeSelf && !menu.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PaAtra();
            }
        }

    }

    public void Empezar()
    {
        menu.SetActive(false);
        nivel1.SetActive(true);
        player.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        canvasPausa.SetActive(false);
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        FindObjectOfType<PlayerController>().GetComponent<PlayerController>().enemies.RemoveRange(0, FindObjectOfType<PlayerController>().GetComponent<PlayerController>().enemies.Count);
        canvasPausa.SetActive(false);
        menu.SetActive(true);
        player.SetActive(false);
        nivel1.SetActive(false);
        nivel2.SetActive(false);
        nivel3.SetActive(false);
        nivel4.SetActive(false);
        

    }

    public void Nivel1()
    {
        selectLevel.SetActive(false);
        menu.SetActive(false);
        nivel1.SetActive(true);
        player.SetActive(true);

        level1 = true;

        Time.timeScale = 1f;
    }
    public void Nivel2()
    {
        selectLevel.SetActive(false);
        menu.SetActive(false);
        nivel2.SetActive(true);
        player.SetActive(true);

        level2 = true;

        Time.timeScale = 1f;
    }

    public void Nivel3()
    {
        selectLevel.SetActive(false);
        menu.SetActive(false);
        nivel3.SetActive(true);
        player.SetActive(true);

        Time.timeScale = 1f;
    }

    public void Nivel4()
    {
        selectLevel.SetActive(false);
        menu.SetActive(false);
        nivel4.SetActive(true);
        player.SetActive(true);

        Time.timeScale = 1f;
    }

    public void Retry()
    {
        nivel1.SetActive(false);
        nivel2.SetActive(false);
        nivel3.SetActive(false);
        nivel4.SetActive(false);
        player.SetActive(false);
        menu.SetActive(false);
        gameOver.SetActive(false);
        selectLevel.SetActive(true);
        //FindObjectOfType<PlayerController>().GetComponent<PlayerController>().enemies.RemoveRange(0, FindObjectOfType<PlayerController>().GetComponent<PlayerController>().enemies.Count);

        emparentEspecial = GameObject.Find("EmparentAtaquesEspeciales");
        for (int i = 0; i < emparentEspecial.transform.childCount; i++)
        {
            Destroy(emparentEspecial.transform.GetChild(i).gameObject);
        }
    }


    public void SelectLevel()
    {
        menu.SetActive(false);
        selectLevel.SetActive(true);
    }
    public void PaAtra()
    {
        selectLevel.SetActive(false);
        menu.SetActive(true);
    }

    public void ActivarNivel()
    {
        if (!levels[1].interactable)
        {
            levels[1].interactable = true;
            levels[1].image.sprite = ole2;
            tex2.SetActive(false);
            text2.SetActive(true);
            return;
        }

        if (!levels[2].interactable)
        {
            levels[2].interactable = true;
            levels[2].image.sprite = ole3;
            tex3.SetActive(false);
            text3.SetActive(true);
            return;
        }

        if (!levels[3].interactable)
        {
            levels[3].interactable = true;
            levels[3].image.sprite = ole4;
            tex4.SetActive(false);
            text4.SetActive(true);
            return;
        }
    }
}
