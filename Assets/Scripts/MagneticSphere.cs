using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class MagnetInfo
{
    public GameObject magnetObject;
    public float strength;
    public bool isActive;
}
public class MagneticSphere : MonoBehaviour
{
    Dictionary<string, MagnetInfo> magnets = new Dictionary<string, MagnetInfo>();
    [SerializeField]
    public void EnableMagnet(Magnet magnetScript, bool isActive)
    {
        string name = magnetScript.GetName();
        if (magnets.ContainsKey(name))
        {
            magnets[name].isActive = isActive;
        }
        else
        {
            MagnetInfo newMagnetInfo= new MagnetInfo();
            newMagnetInfo.magnetObject = magnetScript.gameObject;
            newMagnetInfo.strength = magnetScript.GetStrength();
            newMagnetInfo.isActive = true;
            magnets.Add(name, newMagnetInfo);
        }
    }

    Rigidbody m_rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 previousVelocity = m_rigidbody.velocity;
        bool isAffected = false;
        m_rigidbody.velocity = new Vector3(0, 0, 0);
        foreach (KeyValuePair<string, MagnetInfo> entry in magnets)
        {
            MagnetInfo magnet = entry.Value;
            if (magnet.isActive)
            {
                isAffected = true;
                float xMagnet = magnet.magnetObject.transform.position.x;
                float zMagnet = magnet.magnetObject.transform.position.z;
                float x = transform.position.x;
                float z = transform.position.z;
                float norm = (Mathf.Sqrt(Mathf.Pow(xMagnet - x, 2) + Mathf.Pow(zMagnet - z, 2)));
                float distanceFactor = 1 / norm;
                m_rigidbody.AddForce(Mathf.Pow(distanceFactor, 2) * magnet.strength * new Vector3(xMagnet - x, 0, zMagnet - z).normalized);
            }
        }
        if (!isAffected)
        {
            m_rigidbody.velocity = previousVelocity; //letting the spheres free from magnets move naturally
        }
    }
}
