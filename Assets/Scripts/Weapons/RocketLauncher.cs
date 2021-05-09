using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon
{

    public List<Transform> rocketSpawns;

    public Transform anchorPoint;

    public GameObject rocketBase;
    public GameObject rocket;

    float l_duration;



    void Start()
    {
        Debug.Log("Soy un lanzacohetes!");
        rocket = rocketBase;
        damage = 5;
        l_duration = duration;
    }

    void Update()
    {
        if (rocket == null)
            rocket = rocketBase;
    }

    public override void Fire()
    {
        Debug.Log("Lanzo cohetes putita.");
        l_duration -= Time.deltaTime;
        if (l_duration < 0)
        {
            foreach (Transform tr in rocketSpawns)
            {
                rocket = Instantiate(rocket, tr.transform.position,Quaternion.LookRotation(tr.transform.position - anchorPoint.transform.position));
                rocket.GetComponent<RocketScript>().dir = tr.transform.position - anchorPoint.transform.position;
                l_duration = duration;
            }

        }
        
    }


}
