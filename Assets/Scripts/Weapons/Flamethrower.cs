using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : Weapon
{
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
    }
}
