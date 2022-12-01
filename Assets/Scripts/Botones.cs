using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botones : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnMouseEnter()
    {
        transform.localScale = new Vector2(1.13f, 1.13f);
    }
    public void OnMouseExit()
    {
        transform.localScale = new Vector2(1f, 1f);
    }
}
