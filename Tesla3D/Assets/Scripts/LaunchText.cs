using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;

public class LaunchText : MonoBehaviour
{
    public Transform container;
    public ShipText singlePanel;
    public GameObject button;

    private readonly string launches = "https://api.spacexdata.com/v3/launches";
    
    void Start()
    {
        SendRequest();
        //StartCoroutine(GetText());
        singlePanel.gameObject.SetActive(false);
    }

    async Task SendRequest()
    {
        var resp = await HttpSendRequest.SendRequest(launches) ;
        ParseAndLoad(resp);
    }
    //IEnumerator GetText()
    //{
    //    using (UnityWebRequest request = UnityWebRequest.Get(launches))
    //    {
    //        yield return request.SendWebRequest();

    //        if (request.isNetworkError || request.isHttpError)
    //        {
    //            Debug.Log(request.error);
    //        }
    //        else
    //        {
    //            //ParseAndLoad(request);
    //        }
    //    }
    //}

    private void ParseAndLoad(string response)
    {
     
        var myJson = JsonConvert.DeserializeObject<List<Launch>>(response, new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore
        });

        foreach (var x in myJson)
        {
            GameObject go = Instantiate(button) as GameObject;
            go.transform.SetParent(container);
            go.transform.localScale = Vector3.one;

            go.GetComponentInChildren<TextMeshProUGUI>().text = "Mission name: " + x.mission_name + "\n No. of payloads: " + x.rocket.second_stage.payloads.Count
                + "\n Rocket name: " + x.rocket.rocket_name + "\n Country: " + x.rocket.second_stage.payloads[0].nationality.ToString();

            var lButton = go.GetComponent<LaunchButton>();
            Launch launch = x;
            lButton.SingleLaunch = launch;
            lButton.action = OnButtonClick;

        }
    }
    private void OnButtonClick(Launch launch)
    {
        singlePanel.gameObject.SetActive(true);
        singlePanel.Launch = launch;
    }
}