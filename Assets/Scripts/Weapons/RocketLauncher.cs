using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon
{
    void Start()
    {
        Debug.Log("Soy un lanzacohetes!");
    }

    void Update()
    {
        
    }

    public override void Fire()
    {
        Debug.Log("Lanzo cohetes putita.");
    }
}
