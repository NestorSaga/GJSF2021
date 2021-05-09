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

    public Transform weakPoint;

    // Valores

    public float P2HP, maxP2HP, rotationSpeed;

    // Gestión de inputs

    Vector2 weaponRotation;
    bool weapon_3, weapon_4, weapon_1Cancelled, weapon_2Cancelled, firstBossDown;
    float weapon_2, weapon_1, rotateClockwise, rotateCounterclockwise;

    public void OnRotate_Clockwise(InputAction.CallbackContext ctx) => rotateClockwise = ctx.ReadValue<float>();
    public void OnRotate_Counterclockwise(InputAction.CallbackContext ctx) => rotateCounterclockwise = ctx.ReadValue<float>();
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
        rotationSpeed = 40;
        //Die();
    }

    void Update()
    {

        if (rotateClockwise > 0.1f) RotateCharacter(true);
        else if (rotateCounterclockwise > 0.1f) RotateCharacter(false);

        if (weaponRotation.x != 0) RotateWeapons(weaponRotation);

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

        // Reseteamos bools de input



        weapon_4 = false;

      
    }

    public void RotateCharacter(bool clockwise)
    {

        if(clockwise) transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        else transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);


    }

    public void RotateWeapons(Vector2 dir)
    {
        foreach(Transform tr in transform)
        {
            if(tr.name == "Weapons"){

                tr.Rotate(Vector3.up * (rotationSpeed * dir.x) * Time.deltaTime);
            }
        }
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
        if (P2HP <= 0)
        {
            
            if(firstBossDown)
            {
                DieHarder();
            }
            P2HP = maxP2HP;
            Die();
            firstBossDown = true;

        }

    }

    public void Die()
    {
        foreach(Transform child in transform)
        {
            if(child.name == "Model")
            {
                foreach(Transform garsaChild in child) {

                    if (garsaChild.name == "Outline") Destroy(garsaChild.gameObject);
                    if(garsaChild != null)
                    {
                        garsaChild.GetComponent<Rigidbody>().isKinematic = false;
                        garsaChild.GetComponent<Rigidbody>().AddExplosionForce(3000, garsaChild.position, 5f);

                        garsaChild.GetComponent<MeshCollider>().enabled = true;
                    }
                }
            }
        }

    }

    public void DieHarder()
    {
        GameManager.Instance.win();
    }
}
