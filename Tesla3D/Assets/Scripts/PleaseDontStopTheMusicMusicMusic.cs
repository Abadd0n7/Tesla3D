using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PleaseDontStopTheMusicMusicMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("music");
        if(go.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
