using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FMODUnity
{
    public class Extensions
    {
        public static FMOD.Studio.PLAYBACK_STATE PlaybackState(FMOD.Studio.EventInstance instance)
        {
            FMOD.Studio.PLAYBACK_STATE pS;
            instance.getPlaybackState(out pS);
            return pS;
        }

        public static float GetParameter(FMOD.Studio.EventInstance instance, string parameter)
        {
            float p;
            instance.getParameterByName(parameter, out p);
            return p;
        }

        public static void SetParameter(FMOD.Studio.EventInstance instance, string parameter, float value)
        {
            instance.setParameterByName(parameter, value);
        }

        public static void SetParameter(FMOD.Studio.EventInstance instance, string parameter, float value, bool seekSpeed)
        {

            instance.setParameterByName(parameter, value, seekSpeed);
        }

        public static FMOD.RESULT CheckEvent(string path)
        {
            FMOD.RESULT result;
            result = FMODUnity.RuntimeManager.StudioSystem.getEvent(path, out var fmodEvent);
            if (result != FMOD.RESULT.OK)
            {
                Debug.LogError("Event: " + path + " not found");
                return FMOD.RESULT.ERR_EVENT_NOTFOUND;
            }
            else return result;
        }
    }
}