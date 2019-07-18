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

public class LaunchText : MonoBehaviour
{
    public Transform container;
    public LaunchDataPanel singlePanel;
    public GameObject button;

    private readonly string launches = "https://api.spacexdata.com/v3/launches";
    
    void Start()
    {
        StartCoroutine(GetText());
        singlePanel.gameObject.SetActive(false);
    }

    IEnumerator GetText()
    {
        UnityWebRequest request = UnityWebRequest.Get(launches);
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            string _text;

            _text = request.downloadHandler.text;
            var myJson = JsonConvert.DeserializeObject<List<Launch>>(_text, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            //.FindAll(y => y.ships != null && y.ships.Count > 0)
            foreach (var x in myJson)
            {
                GameObject go = Instantiate(button) as GameObject;
                go.transform.SetParent(container);
                go.transform.localScale = Vector3.one;

                go.GetComponentInChildren<TextMeshProUGUI>().text = "Mission name: " + x.mission_name + "\n No. of payloads: " + x.rocket.second_stage.payloads.Count
                    + "\n Rocket name: " + x.rocket.rocket_name + "\n Country: " + x.rocket.second_stage.payloads[0].nationality.ToString();

                var lButton = go.GetComponent<LaunchBtn>();
                Launch launch = x;
                lButton.SingleLaunch = launch;
                lButton.action = OnButtonClick;

            }
        }
    }
    void OnButtonClick(Launch launch)
    {
        //Debug.Log("działam " + launch.launch_date_local);
        singlePanel.gameObject.SetActive(true);

        singlePanel.L = launch;

    }
}