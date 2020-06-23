using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SoundEffect
{
    public string name;
    public AudioClip audioClip;
    [Range(0,1)]
    public float volume;
}