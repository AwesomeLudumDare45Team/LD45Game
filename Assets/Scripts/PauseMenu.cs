using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
	public GameObject menu;
	public GameObject resumeButton;
	public EventSystem eS;

    private FMOD.Studio.EventInstance pauseInstance;

	void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.isInTimeline)
		{
			if(GameManager.instance.isPaused)
			{
				Resume();
			}
			else
			{
				Time.timeScale = 0.0f;
				GameManager.instance.isPaused = true;
				menu.gameObject.SetActive(true);
				eS.SetSelectedGameObject(resumeButton);

                if (FMODUnity.Extensions.PlaybackState(pauseInstance) != FMOD.Studio.PLAYBACK_STATE.PLAYING)
                { 
                pauseInstance = FMODUnity.RuntimeManager.CreateInstance("snapshot:/Pause");
                pauseInstance.start();
                }
            }
		}
    }

	public void Resume()
	{
		Time.timeScale = 1.0f;
		GameManager.instance.isPaused = false;
		menu.gameObject.SetActive(false);

        if (FMODUnity.Extensions.PlaybackState(pauseInstance) == FMOD.Studio.PLAYBACK_STATE.PLAYING)
        { 
        pauseInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        pauseInstance.release();
        }
    }

	public void Quit()
	{
		Application.Quit();
	}
}
