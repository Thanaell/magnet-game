using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCanvasMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject OVRCenterEye;

    void Update()
    {
        // Follow the OVR headset
        this.transform.position = OVRCenterEye.transform.position;
        this.transform.rotation = OVRCenterEye.transform.rotation;
    }
}
