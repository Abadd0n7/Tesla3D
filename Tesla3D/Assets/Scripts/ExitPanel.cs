using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPanel : MonoBehaviour
{
    public GameObject go;
    public void OnButtonXClick()
    {
        go.SetActive(false);
    }
}
