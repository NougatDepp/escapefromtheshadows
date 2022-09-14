using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{

    private GridTemplates temps;
    private Animator anim;

    public GameObject boss;
    
    void Start()
    {
        temps = GameObject.FindGameObjectWithTag("Grids").GetComponent<GridTemplates>();
        anim = GetComponent<Animator>();
        Instantiate(temps.bossGrids[0], transform.position, Quaternion.identity);
        SpawmEnemy();
    }
    

    void SpawmEnemy()
    {
        Instantiate(boss, transform.position, Quaternion.identity);
    }
    
}
