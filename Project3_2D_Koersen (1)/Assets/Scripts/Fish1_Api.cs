using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
//using UnityEditor.IMGUI.Controls;

public class Fish1_Api : MonoBehaviour
{
    public const string URL = "api.openweathermap.org/data/2.5/weather?id=2759794&units=metric&appid="+API_KEY; // verander locatie
    private const string API_KEY = "9d555c538ff33e5450ae1575097d7b97";
    public Text responseText;

    public string retrievedCountry;
    public string retrievedCity;
    public int conditionID;
    public string conditionName;
    public static float floatTemp;
    public float height;
    
    public Slider netherlandsSlider;
    public Text netCountry;
    public Text netCity;
    public Text netTemperature;
    public Text netCondition;
  
    
    public bool Right;
    public Animator Fish1;
    public GameObject FISH1;
    private Vector3 fishPos;
    
    IEnumerator Start()
    {
        WWW request = new WWW(URL);
        yield return request;
        if (request.error == null || request.error == "Error")
        {
            var N = JSON.Parse(request.text);

            retrievedCountry = N["sys"]["country"].Value;
            retrievedCity = N["name"].Value;

            string temp = N["main"]["temp"].Value;

            float.TryParse(temp, out floatTemp);
            //float finalTemp = Mathf.Round(tempTemp / 100);
            Debug.Log(temp);
            Debug.Log(floatTemp);

            int.TryParse(N["weather"][0]["id"].Value, out conditionID);
            conditionName = N["weather"][0]["description"].Value;

            netCountry.text = "" + retrievedCountry;
            netCity.text = "City:" + retrievedCity;
            netTemperature.text = "Temperature:" + temp + " C";
            netCondition.text = "Condition:" + conditionName;

            //netherlandsSlider.value = finalTemp;
        }
        else
        {
            Debug.Log("WWW error: " + request.error);

        }
    }
    
    // Start is called before the first frame update
    void awake()
    {
         transform.Translate(Time.deltaTime, 0, 0);
         Fish1 = GetComponent<Animator>();
         FISH1 = GameObject.FindGameObjectWithTag("Fish");
    } 

    // Update is called once per frame
    void Update()
    {
        height = floatTemp;
       
         if (transform.position.x <= -7.5)
         {
             Right = true;
             Fish1.SetBool("Left", false);
             Fish1.SetBool("Right", true);
         }

         if (transform.position.x >= 7.5)
         {    
             Right = false;
             Fish1.SetBool("Right", false);
             Fish1.SetBool("Left", true);
         }

         if (Right)
         {
             transform.Translate(Time.deltaTime, 0, 0);
         }
        
         if (Right == false)
         {
            transform.Translate(-Time.deltaTime, 0, 0);
         }

         if (transform.position.x > -7.5 && transform.position.x < 7.5)
         {
            //Debug.Log("SWIM 2");
         }
    }

    public void Onbutton()
    {
        FISH1.transform.position = fishPos;
        fishPos.y = height/1000;   
    }
}