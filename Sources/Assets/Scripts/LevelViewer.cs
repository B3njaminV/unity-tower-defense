using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelViewer : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "Level " + (GameManager.Instance.CurrentLevel + 1).ToString();
    }
}
