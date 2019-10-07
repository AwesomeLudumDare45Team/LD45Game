using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/AudioData", fileName = "New AudioData")]
public class AudioData : ScriptableObject
{
    [Header("Player")]
    [FMODUnity.EventRef]
    public string playerRun = null;

    [FMODUnity.EventRef]
    public string playerJump = null;

    [FMODUnity.EventRef]
    public string collectItem = null;

    [Header("Environment")]
    [FMODUnity.EventRef]
    public string envAppear = null;


    [Header("Music")]
    [FMODUnity.EventRef]
    public string music = null;

    [Header("Local Parameters")]
    public string localParameter = null;

    [Header("Global Parameters")]
    [FMODUnity.ParamRef]
    public string musicParameter = null;

}
