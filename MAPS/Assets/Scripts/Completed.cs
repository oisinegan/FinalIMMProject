using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Completed : MonoBehaviour
{
    public TextMeshProUGUI pointsLabel;

    void Start()
    {
        pointsLabel.text = "Final Score: " + GameManager.points;
    }
    void Update(){}
}
