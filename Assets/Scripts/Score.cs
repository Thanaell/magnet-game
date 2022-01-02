using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public void UpdateScore(int score)
    {
        this.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
    }

}
