using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePulse : Weapon
{


    public GameObject pulseToFill, pulseFilling;

    Vector3 targetScale;

    float speed = 5;

    void Start()
    {
        Debug.Log("Soy un lanzapulsos!");

        foreach (Transform tr in GetComponentInChildren<Transform>())
        {
            if (tr.name == "ToFill") pulseToFill = tr.gameObject;
            if (tr.name == "Filling") pulseFilling = tr.gameObject;
        }

        targetScale = pulseToFill.transform.localScale;
    }

    void Update()
    {
        
    }

    public override void Fire()
    {
        Debug.Log("Lanzo un pulso putita.");

        //if (pulseFilling.transform.localScale != targetScale)
            pulseFilling.transform.localScale = Vector3.Lerp(pulseFilling.transform.localScale, targetScale, speed * Time.deltaTime);



    }
}
