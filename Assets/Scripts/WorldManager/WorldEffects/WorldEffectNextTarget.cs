﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEffectNextTarget : WorldEffect
{
	public Transform nextTarget;

	public override void Initialize()
	{

	}

	public override void Execute()
	{
		if (nextTarget == null)
			GameManager.instance.seeker.arrow.SetActive(false);
		else
			GameManager.instance.seeker.target = nextTarget;
	}
}
