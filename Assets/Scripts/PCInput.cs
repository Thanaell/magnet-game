using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCInput : MonoBehaviour
{
    [SerializeField]
    float speed = 1.0f;

    private void Update()
    {
        Vector3 currentPosition = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentPosition.z += Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentPosition.z -= Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentPosition.x -= Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentPosition.x += Time.deltaTime * speed;
        }

        this.transform.position += currentPosition;
    }
}
