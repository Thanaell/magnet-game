using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    public UnityEvent<int> scoreChangedEvent;
    private int score = 0;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        score += 1;
        scoreChangedEvent.Invoke(score);
    }
}
