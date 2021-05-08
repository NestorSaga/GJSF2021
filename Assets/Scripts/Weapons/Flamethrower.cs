using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : Weapon
{


    public List<Transform> flameSpawns;

    public Transform flameAnchor;

    public GameObject fireParticles;


    public bool instantiated;
    void Start()
    {
        Debug.Log("Soy un lanzallamas!");
    }


    void Update()
    {
        
    }

    public override void Fire()
    {
        Debug.Log("Lanzo llamas putita.");

            foreach (Transform tr in flameSpawns)
            {
                //tr.gameObject.SetActive(true);
                tr.gameObject.GetComponent<BoxCollider>().enabled = true;    
                if(!tr.gameObject.GetComponent<ParticleSystem>().isPlaying)
                    tr.gameObject.GetComponent<ParticleSystem>().Play();

            }
        
    }

    public override void Release()
    {
        foreach (Transform tr in flameSpawns)
        {
            //tr.gameObject.SetActive(false);
            tr.gameObject.GetComponent<BoxCollider>().enabled = false;
            tr.gameObject.GetComponent<ParticleSystem>().Stop();
            
        }
    }

}
