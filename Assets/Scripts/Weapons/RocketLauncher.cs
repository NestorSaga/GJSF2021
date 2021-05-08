using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon
{

    public List<Transform> rocketSpawns;

    public Transform anchorPoint;

    public GameObject rocketBase;
    public GameObject rocket;



    void Start()
    {
        Debug.Log("Soy un lanzacohetes!");
        rocket = rocketBase;
    }

    void Update()
    {
        if (rocket == null)
            rocket = rocketBase;
    }

    public override void Fire()
    {
        Debug.Log("Lanzo cohetes putita.");
        foreach (Transform tr in rocketSpawns)
        {
            rocket = Instantiate(rocket, tr.transform.position, tr.transform.rotation);
            rocket.GetComponent<RocketScript>().dir = tr.transform.position - anchorPoint.transform.position;
        }
    }


}
