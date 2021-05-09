using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksRain : Weapon
{
    public GameObject fireworkPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Fire()
    {
        var rocket = Instantiate(fireworkPrefab, Vector3.up * 15, Quaternion.LookRotation(GameManager.Instance.p1.transform.position - Vector3.up * 15));
        rocket.GetComponent<SkyRocket>().targetPosition = GameManager.Instance.p1.transform.position;
    }
}
