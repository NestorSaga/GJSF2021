using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;
    public float duration;
    public float cooldown;

    public virtual void Fire(){}
}
