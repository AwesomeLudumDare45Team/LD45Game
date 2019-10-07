using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEffectRemoveCollider : WorldEffect
{
	public GameObject obj;

	public override void Initialize()
	{
	}

	public override void Execute()
	{
		Destroy(obj.GetComponent<Collider>());
	}
}
