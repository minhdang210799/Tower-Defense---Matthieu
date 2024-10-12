using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public static void SpawnVFX(ParticleSystem particle, Vector2 position)
    {
        ParticleSystem effect = Instantiate(particle, position, Quaternion.identity);
        effect.Play();
        Destroy(effect, effect.main.duration);
    }
}
