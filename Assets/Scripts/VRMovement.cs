using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRMovement : MonoBehaviour
{
    private void Update()
    {
        if (OVRManager.isHmdPresent)
        {
            this.transform.position = OVRManager.tracker.GetPose().position;
        }
    }
}
