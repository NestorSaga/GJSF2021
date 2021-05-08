﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{



    public  List<Transform> limites;

    public GameObject quadrante;

    public GameObject diablillo;


    float nextActionTime = 0.0f;
    float period = 2f;

    float offset = 1.5f;


    public float maxKnightHP = 50;
    public float currentKnightHP;

    public float maxBossHP = 100;
    public float currentBossHP;


    public Slider knightSlider, bossSlider;

    void Start()
    {
        limites = new List<Transform>();
        llenarLista();
        currentBossHP = maxBossHP;
        currentKnightHP = maxKnightHP;
        setStartingHealth();
    }

    // Update is called once per frame
    void Update()
    {

        if (currentBossHP <= 0) win();
        else if (currentKnightHP <= 0) lose();



            if (Time.time > nextActionTime)
            {

                //Minions objetive
                nextActionTime += period;
                int random = Random.Range(0, limites.Count);
                Vector3 position = new Vector3(limites[random].position.x - offset * 2, offset, limites[random].position.z - offset * 2);
                //Vector3 position = limites[random].forward +  new Vector3(0,offset,0);

                //Spawn minions
                diablillo = Instantiate(diablillo, position, Quaternion.identity);
                if (period % 2 == 0)
                    diablillo.GetComponent<DiablilloScript>().target = limites[limites.Count - random + 2];
                else
                    diablillo.GetComponent<DiablilloScript>().target = limites[limites.Count - random - 2];

            }
    }

    void llenarLista()
    {
        foreach (Transform child in quadrante.transform)
        {
            limites.Add(child);
        }
    }

    public void setStartingHealth()
    {
        knightSlider.maxValue = maxKnightHP;
        knightSlider.value = maxKnightHP;

        bossSlider.maxValue = maxBossHP;
        bossSlider.value = maxBossHP;
    }

    public void takeDamage(int dmg, int id)
    {
        if (id == 0) knightSlider.value -= dmg;
        else bossSlider.value -= dmg;        
    }


    public void win()
    {

    }

    public void lose()
    {

    }


}