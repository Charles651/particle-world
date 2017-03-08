using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private static GameController _instance;     //much better with singletons
    public static GameController instance{
        get{
            if (_instance == null)      //This will only happen the first time this reference is used.
                _instance = GameObject.FindObjectOfType<GameController>();
            return _instance;
        }
    }

    public GameObject[] m_Atom;
    public GameObject m_Molecule;
    public GameObject m_Center;
    public int m_AtomCount;
    // Use this for initialization
    void Awake () {
        m_Atom = GameObject.FindGameObjectsWithTag("Atom");
        m_AtomCount = m_Atom.Length;
        m_Molecule = GameObject.FindGameObjectWithTag("Molecule");
        m_Center = m_Atom[0];

        foreach (GameObject atom in m_Atom){
            atom.GetComponent<MeshRenderer>().enabled = true;
        }
        m_Molecule.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update () {
        Vector3 posSum=new Vector3(0,0,0);
        if (m_AtomCount <= 1) {
            foreach (GameObject atom in m_Atom)
            {
                posSum += atom.transform.position;
                atom.GetComponent<MeshRenderer>().enabled = false;
                if (atom.GetComponent<ParticleSystem>())
                    atom.GetComponent<ParticleSystem>().Stop();
            }
            m_Molecule.GetComponent<MeshRenderer>().enabled = true;
            m_Molecule.transform.position = posSum / m_AtomCount;
        }
        else
        {
            foreach (GameObject atom in m_Atom)
            {
                atom.GetComponent<MeshRenderer>().enabled = true;
                if (atom.GetComponent<ParticleSystem>())
                    atom.GetComponent<ParticleSystem>().Play();

            }
            m_Molecule.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
