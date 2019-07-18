using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;
using Newtonsoft.Json;

public class LaunchDataPanel : MonoBehaviour
{
    private Launch l;
    public TextMeshProUGUI text;

    private string API = "https://api.spacexdata.com/v3/ships";

    public Launch L { set { setLaunch(value); } }

    private void setLaunch(Launch launch)
    {
        l = launch;
        text.text = "";
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        UnityWebRequest request = UnityWebRequest.Get(API);
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            string _text;

            _text = request.downloadHandler.text;
            var myJson = JsonConvert.DeserializeObject<List<Ship>>(_text, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            if (l.ships == null || l.ships.Count == 0)
            {
                text.text = "No ship info available! \nLaunch failed or not in progress yet!";
            }
            else
            {

                string xxx = "";
                foreach (var ship in l.ships)
                {
                    var shipData = myJson.Find(x => x.ship_id == ship);
                    xxx +="Ship name: " + shipData.ship_name + "\nType: " + shipData.ship_type + "\nNo. of missions: " + shipData.missions.Count + "\nHome port: " + shipData.home_port + "\n ";
                }
                text.text = xxx;
            }

        }
    }
}
