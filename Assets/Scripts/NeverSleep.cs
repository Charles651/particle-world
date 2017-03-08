using UnityEngine;
using System.Collections;

public class NeverSleep : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    void OnGUI()
    {
        Event e = Event.current;
        GUI.Label(new Rect(10.0f, 10.0f, 300.0f, 45.0f), "KeyCode:");
        if (e.isKey)
        {
            GUI.Label(new Rect(10.0f, 10.0f, 300.0f, 45.0f), "KeyCode:" + e.keyCode);
            Debug.Log("KeyCode:" + e.keyCode);
        }
    }
}