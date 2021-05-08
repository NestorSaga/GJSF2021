using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : Weapon
{


    public List<Transform> flameSpawns;

    public Transform flameAnchor;

    public GameObject fireParticles;
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
            tr.GetComponent<BoxCollider>().enabled = true;
            fireParticles = Instantiate(fireParticles, tr.transform.position,Quaternion.LookRotation(tr.transform.position - flameAnchor.transform.position, new Vector3(0,0,0)));
            fireParticles.transform.parent = gameObject.transform;

        }

    }
}
