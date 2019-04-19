using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

	
	private float fillAmount;
	[SerializeField]
	//the speed at wich the bar goes down with
	private float lerpSpeed;

	[SerializeField]
	private Image content;

	[SerializeField]
	private Text valueText ;
	public float MaximumValue { get; set;}

	public float Value
	{
		set
		{	
			string[] tmp = valueText.text.Split(':');
			valueText.text = tmp[0] + ": " + value;
			fillAmount = Map(value,0,MaximumValue,0,1);
		}
	}
	
	void Update () {
	
	
	HandleBar();
	}

	 private void HandleBar()
	 {	
		 if (fillAmount != content.fillAmount)
		 {
			content.fillAmount = Mathf.Lerp(content.fillAmount,fillAmount,Time.deltaTime*lerpSpeed );
		}
	 }

	 private float Map ( float value, float inMin, float inMax, float outMin, float outMax)
	 {
		 return(value - inMin ) * (outMax - outMin) / (inMax - inMin) + outMin;
	 	//   (80-0) * (1 - 0) / (100 - 0) + 0    
	 } 
}

