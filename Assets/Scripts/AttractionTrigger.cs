using UnityEngine;
using System.Collections;

public class AttractionTrigger : MonoBehaviour {
    public GameObject m_Node;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if ((this.transform.position-m_Node.transform.position).sqrMagnitude<=35)
            for (var i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<BeingAttracted>().enabled = true;
            }
        else
            for (var i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<BeingAttracted>().enabled = false;
            }
    }
}
