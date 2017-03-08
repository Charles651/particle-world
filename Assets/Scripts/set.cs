using UnityEngine;
using System.Collections;

public class set : MonoBehaviour {
    public float viewAspect = 1.778f;
    GameObject rubbish;
    // Use this for initialization
    void Start () {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        GetComponent<Camera>().aspect = viewAspect;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
