using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Api : MonoBehaviour
{
    private const string API_KEY = "bd3c3ba5e9a485c081d34e8084941e7d";
    private const string URL = "api.openweathermap.org/data/2.5/weather?id=2759794&units=metric&appid="+API_KEY;
    private const string URL_2 = "api.openweathermap.org/data/2.5/weather?id=6058560&mode=+xml&appid="+API_KEY;
    
    public Text responseText;
    public Text responseText2;
    
    public IEnumerator Request()
    {
      /*UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.Send();

        if (www.isError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }
        /*WWW request = new WWW(URL);
        StartCoroutine(onResponse(request));
        
        WWW request2 = new WWW(URL_2);
        StartCoroutine(onResponse2(request2));#1#*/
        


        WWW www = new WWW(URL);

        while (!www.isDone)

            yield return null;

        if (string.IsNullOrEmpty (www.error)) {

            Debug.Log (www.text);

        } else

            Debug.Log (www.error);
    }
    
    
    private IEnumerator onResponse(WWW req)
    {
        yield return req;

        responseText.text = req.text;
    }

    private IEnumerator onResponse2(WWW request2)
    {
        yield return request2;

        responseText2.text = request2.text;
    }

    //private IEnumerator onRequest(temp)
    
}
