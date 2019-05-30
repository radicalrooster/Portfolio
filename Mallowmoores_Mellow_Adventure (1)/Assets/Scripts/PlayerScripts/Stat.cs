using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stat
{
	[SerializeField]
	private BarScript bar;

	[SerializeField]
	private float maxVal;

	[SerializeField]
	private float currentVAL;
	public float Currentval
	{
		get 
		{
			return currentVAL;
		}
		set
		{		
			this.currentVAL = Mathf.Clamp(value,0,MaximumVal);
			bar.Value = currentVAL;
		}
	}

	public float MaximumVal
	{	
		get
		{
			return maxVal;
		}
		set
		{	
		this.maxVal = value;
		bar.MaximumValue = value;
		}
	}

	public void Initialize()
		{
			this.MaximumVal = maxVal; 
			this.Currentval = currentVAL;
		}
}