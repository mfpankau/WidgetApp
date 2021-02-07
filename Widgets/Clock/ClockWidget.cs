using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeWidgetScript : MonoBehaviour
{
    public Text text;
    private string time;

    // Start is called before the first frame update
    void Start()
    {
        time = System.DateTime.Now.ToString("HH:mm");
        text.text = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (time != System.DateTime.Now.ToString("HH:mm"))
        {
            time = System.DateTime.Now.ToString("HH:mm");
            text.text = time;
        }
    }
}
