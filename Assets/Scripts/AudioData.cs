using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/AudioData", fileName = "New AudioData")]
public class AudioData : ScriptableObject
{
    [Header("Player")]
    [FMODUnity.EventRef]
    public string test = null;

    [Header("Environment")]
    [FMODUnity.EventRef]
    public string testEvent = null;

    [Header("Music")]
    [FMODUnity.EventRef]
    public string music = null;

    [Header("Local Parameters")]
    public string localParameter = null;

    [Header("Global Parameters")]
    [FMODUnity.ParamRef]
    public string parameter = null;

}
