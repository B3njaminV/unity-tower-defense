using UnityEngine;

public class SunScript : MonoBehaviour
{

    public int creditValue = 50;

    private RectTransform rt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    private void Update()
    {
        rt.Rotate(Vector3.back * Time.deltaTime * 50);
    }

    public void OnMouseUp()
    {
        GameObject.FindGameObjectWithTag("MoneyController")?.GetComponent<MoneyController>()?.AddMoney(creditValue);
        Destroy(gameObject);
    }
}
