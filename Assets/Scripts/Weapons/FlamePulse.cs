using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePulse : Weapon
{
    void Start()
    {
        Debug.Log("Soy un lanzapulsos!");
    }

    void Update()
    {
        
    }

    public override void Fire()
    {
        Debug.Log("Lanzo un pulso putita.");
    }
}
