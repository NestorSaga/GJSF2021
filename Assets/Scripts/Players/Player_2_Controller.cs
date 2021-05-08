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

    //Referencias

    GameManager gm;

    // Valores

    public float P2HP, maxP2HP;

    // Gestión de inputs

    Vector2 weaponRotation;
    bool rotateClockwise, rotateCounterclockwise, weapon_3, weapon_4, weapon_1Cancelled, weapon_2Cancelled;
    float weapon_2, weapon_1;

    public void OnRotate_Clockwise(InputAction.CallbackContext ctx) => rotateClockwise = ctx.ReadValueAsButton();
    public void OnRotate_Counterclockwise(InputAction.CallbackContext ctx) => rotateCounterclockwise = ctx.ReadValueAsButton();
    public void OnRotateWeapon(InputAction.CallbackContext ctx) => weaponRotation = ctx.ReadValue<Vector2>();
    public void OnWeapon_1(InputAction.CallbackContext ctx) 
    {

        weapon_1Cancelled = ctx.canceled;
        weapon_1 = ctx.ReadValue<float>();


    } //=> 
    public void OnWeapon_2(InputAction.CallbackContext ctx)
    {
        weapon_2Cancelled = ctx.canceled;
        weapon_2 = ctx.ReadValue<float>();

    } 
    public void OnWeapon_3(InputAction.CallbackContext ctx) => weapon_3 = ctx.ReadValueAsButton();
    public void OnWeapon_4(InputAction.CallbackContext ctx) => weapon_4 = ctx.ReadValueAsButton();
    public void OnPause(InputAction.CallbackContext ctx) => Debug.Log("Pause!"); // Quiza ni lo termine haciendo el player en si...


    void Start()
    {
        P2HP = maxP2HP;
    }

    void Update()
    {
        if (weapon_1 > 0.1f)
        {
            Attack_Weapon_1();
        }
        else if (weapon_1Cancelled) Release_Weapon1();

        if (weapon_2 > 0.1f)
        {
            Attack_Weapon_2();
        }
        else if (weapon_2Cancelled) Release_Weapon_2();


        if (weapon_3)
        {
            Attack_Weapon_3();
        }

        if (weapon_4)
        {
            Attack_Weapon_4();
        }

        Debug.Log("" + weapon_1);


        // Reseteamos bools de input
        rotateClockwise = false;
        rotateCounterclockwise = false;


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


    public void Release_Weapon1()
    {
        var w = weapons.weapon_1.GetComponent(typeof(Weapon)) as Weapon;
        w.Release();
    }
    public void Release_Weapon_2()
    {
        var w = weapons.weapon_2.GetComponent(typeof(Weapon)) as Weapon;
        w.Release();
    }

    public void TakeDamage(float quantity)
    {
        P2HP -= quantity;

    }

    public void Die()
    {

    }
}
