using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineDirector : MonoBehaviour
{
	private PlayableDirector director;

	public PlayableAsset startTimeline;
	public PlayableAsset endTimeline;

	public GameObject UIPhazeBorders;
	public GameObject firstItem;

	public CameraBehaviour camFollow;

	private void Awake()
	{
		director = GetComponent<PlayableDirector>();
	}

	public void StartTimeline()
	{
		director.playableAsset = startTimeline;
		GameManager.instance.isPaused = true;
		GameManager.instance.isInTimeline = true;
		GameManager.instance.player.SetActive(false);
		UIPhazeBorders.SetActive(false);
		firstItem.SetActive(false);

		director.Play();
		director.stopped += WhenStartTimelineEnded;
	}

	public void WhenStartTimelineEnded(PlayableDirector obj)
	{
		GameManager.instance.isPaused = false;
		GameManager.instance.isInTimeline = false;
		GameManager.instance.player.SetActive(true);
		UIPhazeBorders.SetActive(true);
		firstItem.SetActive(true);
	}

	public void EndTimeline()
	{
		director.playableAsset = endTimeline;
		GameManager.instance.isPaused = true;
		GameManager.instance.isInTimeline = true;
		UIPhazeBorders.SetActive(false);
		camFollow.enabled = false;

		director.Play();
		director.stopped += WhenEndTimelineEnded;
	}

	public void WhenEndTimelineEnded(PlayableDirector obj)
	{
        StopMusic();
		Application.Quit();
    }


    private void StopMusic()
    {
        var findMusic = firstItem.GetComponent<ItemPickUp>().musicInstance;
        findMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        findMusic.release();
    }
}
