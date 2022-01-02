using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField]
    string magnetName = "testMagnet";

    [SerializeField]
    float strength = 10.0f;

    public string GetName()
    {
        return magnetName;
    }
    public float GetStrength()
    {
        return strength;
    }

    private void OnTriggerEnter(Collider other)
    {
        MagneticSphere sphere = other.GetComponent<MagneticSphere>();
        if (sphere)
        {
            sphere.EnableMagnet(this, true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        MagneticSphere sphere = other.GetComponent<MagneticSphere>();
        if (sphere)
        {
            sphere.EnableMagnet(this, false);
        }
    }
}
