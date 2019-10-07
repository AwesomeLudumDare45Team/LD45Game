using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public List<WorldEffect> m_worldEffectList;
    public bool m_revertEffect = false;
    public bool m_debugDisableRemove;
    private bool m_deactivateNotDestroy = true;

    [SerializeField]
    private float musicParameter;

    [SerializeField]
    private bool setMusicParameter, startMusic, playSFX = false;

    private FMOD.Studio.EventInstance musicInstance;

    void Start()
    {
        m_debugDisableRemove = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp();

            FMODUnity.RuntimeManager.PlayOneShotAttached(GameManager.CurrentAudioData.collectItem, this.gameObject);

            if (playSFX)
            {           
            FMODUnity.RuntimeManager.PlayOneShotAttached(GameManager.CurrentAudioData.envAppear, this.gameObject);
            }

            if (startMusic)
            {
                StartMusic();
            }

            if (setMusicParameter)
            {
                ChangeMusicParameter();
            }
        }
    }

    public void PickUp()
    {
        foreach (WorldEffect worldEffect in m_worldEffectList)
        {
            if(worldEffect != null)
            {
                if (m_revertEffect)
                    worldEffect.Initialize();
                else
                    worldEffect.Execute();
            }
        }

        if (!m_revertEffect && !m_debugDisableRemove)
        {
            if (m_deactivateNotDestroy)
                gameObject.SetActive(false);
            else
                Destroy(gameObject);
        }
    }

    private void ChangeMusicParameter()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName(GameManager.CurrentAudioData.musicParameter, musicParameter);
    }

    private void StartMusic()
    {
        if (FMODUnity.Extensions.PlaybackState(musicInstance) != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            musicInstance = FMODUnity.RuntimeManager.CreateInstance(GameManager.CurrentAudioData.music);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName(GameManager.CurrentAudioData.musicParameter, 0f);
            musicInstance.start();
        }
    }
}
