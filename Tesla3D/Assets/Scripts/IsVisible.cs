using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsVisible : MonoBehaviour
{
    public GameObject[] go;
    void Start()
    {
        foreach(var g in go)
        {
            g.SetActive(false);
        }
        //StartCoroutine(ex(g.SetActive(true)));
        //go.SetActive(false);
    }
    void OnTriggerEnter(Collider col)
    {
        foreach (var g in go)
        {
            g.SetActive(true);
            StartCoroutine(ex(g));
        }
        //go.SetActive(true);

    }

    IEnumerator ex(GameObject g)
    {
        yield return new WaitForSeconds(10);
        g.SetActive(false);
    }
}
