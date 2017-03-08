using UnityEngine;
using System.Collections;

public class GetRelatedObject : MonoBehaviour{

    public GameObject m_RelatedObject;
    public GameObject m_ObjectInHierarchy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTargetFound()
    {
        //base.OnTargetFound(recoResult);
        m_ObjectInHierarchy = Instantiate(m_RelatedObject);
        m_ObjectInHierarchy.transform.IsChildOf(this.transform);
        m_ObjectInHierarchy.transform.position = this.transform.position;
        m_ObjectInHierarchy.transform.rotation = this.transform.rotation;
    }
    public void OnTargetLost()
    {
        //base.OnTargetLost(recoResult);
        DestroyObject(m_ObjectInHierarchy);
    }
}
