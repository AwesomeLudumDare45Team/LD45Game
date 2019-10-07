using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
	public static GameManager instance { get; private set; }
	[HideInInspector]
	public bool isPaused;

	public bool introScene;
	public TimelineDirector director;
	[HideInInspector]
	public bool isInTimeline;

	public GameObject player;

    public Boundaries worldBoundaries;
	public bool drawBorder;

	public TargetSeeker seeker;

    private AudioData audioData;

    public static AudioData CurrentAudioData
    {
        get
        {
            return instance.audioData;
        }
    }

    private void OnDrawGizmos()
	{
		if(drawBorder)
		{
			Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.25f);

			float width = worldBoundaries.m_maxPosition.x - worldBoundaries.m_minPosition.x;
			float height = worldBoundaries.m_maxPosition.y - worldBoundaries.m_minPosition.y;
			Vector3 center = new Vector3(worldBoundaries.m_minPosition.x + width /2, worldBoundaries.m_minPosition.y + height / 2, 0.0f);

			Gizmos.DrawCube(center, new Vector3(width, height, 0.1f));
		}
	}

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(this.gameObject);
		}

        audioData = Resources.Load<AudioData>("ScriptableObjects/AudioData");
		if (introScene)
		{
			player.SetActive(false);
			StartCoroutine(LaunchStartTimeline());
		}
	}

	IEnumerator LaunchStartTimeline()
	{
		yield return new WaitForEndOfFrame();
		director.StartTimeline();
	}
}
