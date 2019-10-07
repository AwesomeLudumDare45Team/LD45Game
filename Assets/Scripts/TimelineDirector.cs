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
		director.stopped += WhenEnded;
	}

	public void WhenEnded(PlayableDirector obj)
	{
		GameManager.instance.isPaused = false;
		GameManager.instance.isInTimeline = false;
		GameManager.instance.player.SetActive(true);
		UIPhazeBorders.SetActive(true);
		firstItem.SetActive(true);
	}
}
