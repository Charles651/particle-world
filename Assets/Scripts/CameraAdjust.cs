using UnityEngine;
using System.Collections;

public class CameraAdjust : MonoBehaviour {

    int count;
    GameObject camera_L;
    GameObject camera_R;
    GameObject rubbish;

    // Use this for initialization
    void Start () {
        count = 0;
        camera_L = GameObject.Find("Camera_L");
        camera_R = GameObject.Find("Camera_R");

    }

    // Update is called once per frame
    void Update () {
        transform.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        rubbish = GameObject.Find("camera source");
        Destroy(rubbish);
        rubbish = GameObject.Find("camera background");
        Destroy(rubbish);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            count--;
            if (count < 0)
                count = 4;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            count++;
            if (count > 4)
                count = 0;
        }
        Adjust();

    }
    void Adjust()
    {
        float dis;
        switch (count)
        {
            case 0: //瞳距调节
                dis = Input.GetAxis("Horizontal") * Time.deltaTime;
                camera_L.transform.localPosition -= new Vector3(dis, 0, 0);
                camera_R.transform.localPosition += new Vector3(dis, 0, 0);
                break;
            case 1: //高度调节
                dis = Input.GetAxis("Horizontal") * Time.deltaTime;
                camera_L.transform.localPosition += new Vector3(0, dis, 0);
                camera_R.transform.localPosition += new Vector3(0, dis, 0);
                break;
            case 2: //前后调节
                dis = Input.GetAxis("Horizontal") * Time.deltaTime;
                camera_L.transform.localPosition += new Vector3(0, 0, dis);
                camera_R.transform.localPosition += new Vector3(0, 0, dis);
                break;
            case 3: //俯仰调节
                dis = Input.GetAxis("Horizontal") * Time.deltaTime;
                camera_L.transform.localEulerAngles += new Vector3(dis, 0, 0);
                camera_R.transform.localEulerAngles += new Vector3(dis, 0, 0);
                break;
            case 4: //视场角调节
                dis = Input.GetAxis("Horizontal") * Time.deltaTime * 2;
                camera_L.GetComponent<Camera>().fieldOfView += dis;
                camera_R.GetComponent<Camera>().fieldOfView += dis;
                break;
        }
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 30;
        style.normal.textColor = new Color(1, 1, 1);
        GUI.Label(new Rect(10.0f, 10.0f, 300.0f, 45.0f), "瞳孔位置：" + camera_R.transform.localPosition, style);
        GUI.Label(new Rect(10.0f, 50.0f, 300.0f, 45.0f), "俯角：" + camera_R.transform.localEulerAngles.x, style);
        GUI.Label(new Rect(10.0f, 90.0f, 300.0f, 45.0f), "视场角：" + camera_R.GetComponent<Camera>().fieldOfView, style);
    }

}