using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public static EffectsManager Instance;

    [System.Serializable]
    public class Effect
    {
        public string name;
        public GameObject effect;
    }

    public Effect [] effects;

    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else Destroy(this);
    }

    public void InstantiateEffect(string name, Vector3 position)
    {
        foreach (Effect e in effects)
        {
            if(e.name == name)
            {
                Instantiate(e.effect, position, Quaternion.identity);
            }
        }
    }
}
