using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractedBody : MonoBehaviour
{
	public Rigidbody2D rb;

	void OnEnable()
	{
		if (PullingBody.attracteds == null)
		{
			PullingBody.attracteds = new List<AttractedBody>();
		}

		PullingBody.attracteds.Add(this);
	}

	void OnDisable()
	{
		PullingBody.attracteds.Remove(this);
	}
}
