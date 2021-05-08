using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2_Controller : MonoBehaviour
{
    [System.Serializable]
    public class Weapons
    {
        public GameObject weapon_1;
        public GameObject weapon_2;
        public GameObject weapon_3;
        public GameObject weapon_4;
    }
    public Weapons weapons = new Weapons();

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack_Weapon_1();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Attack_Weapon_2();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack_Weapon_3();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Attack_Weapon_4();
        }
    }

    public void RotateCharacter(float direction)
    {

    }

    public void RotateWeapons(float direction)
    {

    }

    public void Attack_Weapon_1()
    {
        var w = weapons.weapon_1.GetComponent(typeof(Weapon)) as Weapon;
        w.Fire();
    }

    public void Attack_Weapon_2()
    {
        var w = weapons.weapon_2.GetComponent(typeof(Weapon)) as Weapon;
        w.Fire();
    }

    public void Attack_Weapon_3()
    {
        var w = weapons.weapon_3.GetComponent(typeof(Weapon)) as Weapon;
        w.Fire();
    }

    public void Attack_Weapon_4()
    {
        var w = weapons.weapon_4.GetComponent(typeof(Weapon)) as Weapon;
        w.Fire();
    }

    public void TakeDamage(float quantity)
    {

    }

    public void Die()
    {

    }
}
