using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

public class LaunchBtn : MonoBehaviour
{

    public Button btn;
    public Action<Launch> action;
    public TextMeshProUGUI text;
    public Image img;

    private Launch l;

    public Launch SingleLaunch { set { SetSingleLaunch(value); } }

    private void SetSingleLaunch(Launch launch)
    {
        l = launch;

        if(l.launch_date_utc < DateTime.UtcNow)
        {
            img.color = new Color(0, 0.6f, 0, 1f);
        }
        else
        {
            img.color = new Color(0.6f, 0, 0, 0.7f);
        }
    }

    void OnClick()
    {
        action?.Invoke(l);
    }

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(OnClick);
    }
}
