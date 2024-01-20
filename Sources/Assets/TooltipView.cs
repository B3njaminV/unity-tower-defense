using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipView : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        Invoke("DestroyThis", 1);
    }

    public void SetText(string text)
    {
        this.text.text = text;
    }

    private void DestroyThis()
    {
        Destroy(gameObject);
    }
}
