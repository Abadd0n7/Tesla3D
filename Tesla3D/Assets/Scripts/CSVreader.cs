using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;
using TMPro;

public class CSVreader : MonoBehaviour
{
    public TextMeshProUGUI obj;
    public Transform car;
    public TextAsset pathToFile;


    void Reader()
    {
        using (var reader = new StreamReader(@"Assets\Orbital.csv"))
        {
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                listA.Add(values[0]);
            }
            for(int i = 1; i < listA.Count; i++)
            {
                Debug.Log(float.Parse(listA[i]));
            }
        }
        
    }


    List<CSVfile> list = new List<CSVfile>();
    void Start()
    {
        //pathToFile = Resources.Load<TextAsset>("Asset/Orbital.csv");
        string[] data = pathToFile.text.Split(new char[] { '\n' });
        for (int i = 1; i < data.Length - 1; i++)
        {
            string[] values = data[i].Split(new char[] { ',' });
            CSVfile file = new CSVfile();

            float.TryParse(values[0], System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture, out file.A);
            DateTime.TryParse(values[1], System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.AdjustToUniversal,out file.B);
            float.TryParse(values[2], System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture, out file.C);
            float.TryParse(values[3], System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture, out file.D);
            float.TryParse(values[4], System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture, out file.E);
            float.TryParse(values[5], System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture, out file.F);
            float.TryParse(values[6], System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture, out file.G);
            float.TryParse(values[7], System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture, out file.H);
            float.TryParse(values[8], System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture, out file.I);

            list.Add(file);
        }
        //double.TryParse(s, System.Globalization.NumberStyles.Float,
        //System.Globalization.CultureInfo.InvariantCulture, out f
        Debug.Log(list[16].B.ToLocalTime());
    }

    void Update()
    {
        obj.text = "[ " + car.position.x + ", " + car.position.y + ", " + car.position.z + "]";
    }
}

public class CSVfile
{
    public float A;
    public DateTime B;
    public float C;
    public float D;
    public float E;
    public float F;
    public float G;
    public float H;
    public float I;
}