﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FP_Timer : FP_Main
{
	float lastTime;
	public float _initialDelay;
	public float _delay;

	public int _repeatNumber = 9999;

	public UnityEvent OnRepeat;

	private void Awake()
	{
		if(_repeatNumber == 0) Destroy(this);

		StartCoroutine(Timing());
	}

	IEnumerator Timing()
	{
		yield return new WaitForSeconds(_initialDelay);

		OnRepeat.Invoke();
		int i = 1;

		float t = 0;
		lastTime = Time.time;

		while(i<=_repeatNumber)
		{
			if(_enable)
			{
				t += Time.deltaTime;
				if(Time.time>lastTime+_delay)
				{
					OnRepeat.Invoke();
					lastTime = Time.time;
				}
			}
            else
            {
                lastTime = Time.time;
            }
			yield return null;
		}

		Destroy(this);
	}
}
