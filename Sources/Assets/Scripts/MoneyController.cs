using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    [SerializeField]
    private Text moneyField;

    [SerializeField]
    private ScenarioManager scenarioManager;

    public int money { get; private set; } = 0;

    void Start()
    {
        money = scenarioManager.StartingRessources;
        DisplayMoney();
    }

    public void AddMoney(int moneyToAdd)
    {
        money += moneyToAdd;
        DisplayMoney();
    }

    public bool RemoveMoney(int moneyToRemove)
    {
        if (money < moneyToRemove) { return false; }

        money -= moneyToRemove;
        DisplayMoney();
        return true;
    }

    private void DisplayMoney()
    {
        moneyField.text = money.ToString();
    }
}
