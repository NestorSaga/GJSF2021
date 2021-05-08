using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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


    // Gestión de inputs
    Vector2 weaponRotation;
    bool rotateClockwise, rotateCounterclockwise, weapon_1, weapon_2, weapon_3, weapon_4;

    public void OnRotate_Clockwise(InputAction.CallbackContext ctx) => rotateClockwise = ctx.ReadValueAsButton();
    public void OnRotate_Counterclockwise(InputAction.CallbackContext ctx) => rotateCounterclockwise = ctx.ReadValueAsButton();
    public void OnRotateWeapon(InputAction.CallbackContext ctx) => weaponRotation = ctx.ReadValue<Vector2>();
    public void OnWeapon_1(InputAction.CallbackContext ctx) => weapon_1 = ctx.ReadValueAsButton();
    public void OnWeapon_2(InputAction.CallbackContext ctx) => weapon_2 = ctx.ReadValueAsButton();
    public void OnWeapon_3(InputAction.CallbackContext ctx) => weapon_3 = ctx.ReadValueAsButton();
    public void OnWeapon_4(InputAction.CallbackContext ctx) => weapon_4 = ctx.ReadValueAsButton();
    public void OnPause(InputAction.CallbackContext ctx) => Debug.Log("Pause!"); // Quiza ni lo termine haciendo el player en si...


    void Start()
    {
        
    }

    void Update()
    {
        if (weapon_1)
        {
            Attack_Weapon_1();
        }

        if (weapon_2)
        {
            Attack_Weapon_2();
        }

        if (weapon_3)
        {
            Attack_Weapon_3();
        }

        if (weapon_4)
        {
            Attack_Weapon_4();
        }



        Debug.Log("" + weapon_2);


        // Reseteamos bools de input
        rotateClockwise = false;
        rotateCounterclockwise = false;
        weapon_1 = false;
        weapon_2 = false;
        weapon_3 = false;
        weapon_4 = false;

      
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
