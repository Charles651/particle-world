using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour {

    private bool isAlone;
    private bool preStatus;
    private int m_AtomCount;
    public GameObject m_Center;
    public bool GetStatus() {
        return isAlone;
    }
    public void SetStatus(bool status){
        isAlone = status;
    }
	// Use this for initialization
	void Start () {
        m_Center = GameController.instance.m_Center;
        m_AtomCount = GameController.instance.m_AtomCount;
        isAlone = false;
        preStatus = isAlone;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject != m_Center)
        {
            if ((transform.position - m_Center.transform.position).sqrMagnitude <= 6)
            {
                isAlone = true;
            }
            else
            {
                isAlone = false;
            }
            if (isAlone == false && preStatus == true)
            {
                GameController.instance.m_AtomCount++;
            }
            else if (isAlone == true && preStatus == false)
            {
                GameController.instance.m_AtomCount--;
            }
            preStatus = isAlone;
        }
	}
}
