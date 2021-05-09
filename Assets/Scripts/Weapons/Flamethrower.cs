using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : Weapon
{


    public List<Transform> flameSpawns;

    public Transform flameAnchor;

    public GameObject fireParticles;


    public bool instantiated;
    bool playedOnce;
    void Start()
    {

    }


    void Update()
    {
        
    }

    public override void Fire()
    {

            foreach (Transform tr in flameSpawns)
            {
                //tr.gameObject.SetActive(true);
                tr.gameObject.GetComponent<BoxCollider>().enabled = true;    
                if(!tr.gameObject.GetComponent<ParticleSystem>().isPlaying)
                    tr.gameObject.GetComponent<ParticleSystem>().Play();

            }

        if (!playedOnce)
        {
            SoundManager.Instance.PlaySound(SoundManager.Sound.player2Flamethrower1);
            SoundManager.Instance.PlaySound(SoundManager.Sound.player2Flamethrower2);
            playedOnce = true;
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
        playedOnce = false;
        SoundManager.Instance.audioSource.Stop();
    }

}
