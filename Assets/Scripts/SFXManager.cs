using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXManager : MonoBehaviour
{
    static AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    static public void PlaySound(AudioClip clip, float minVol = 1, float maxVol = 1, float minPitch = 1, float maxPitch = 1)
    {
        if (clip == null) return;
        source.clip = clip;
        float ranVol = Random.Range(minVol, maxVol);
        float ranPitch = Random.Range(minPitch, maxPitch);
        source.volume = ranVol;
        source.pitch = ranPitch;
        source.Play();
    }
}
