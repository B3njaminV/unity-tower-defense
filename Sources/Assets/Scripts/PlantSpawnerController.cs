using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlantSpawnerController : MonoBehaviour
{
    public Transform spawner;
    public GameObject tooltipPrefab;

    private PlantMapperController mapper;
    
    private GameObject currentPlant = null;

    private MoneyController moneyController = null;

    private void Start()
    {
        mapper = GameObject.FindGameObjectWithTag("PlantMapper").gameObject.GetComponent<PlantMapperController>();
        moneyController = GameObject.FindGameObjectWithTag("MoneyController").gameObject.GetComponent<MoneyController>();
    }

    public void onClick()
    {
        ShopController.PlantButton selectedPlant = ShopController.Instance.selectedPlant;
        if (currentPlant == null && moneyController.RemoveMoney(selectedPlant.price))
        {
            currentPlant = Instantiate(mapper.GetPlantPrefab(selectedPlant.plant), spawner);
        }
        else if(currentPlant == null)
        {
            GameObject tt = Instantiate(tooltipPrefab, spawner);
            tt.GetComponent<TooltipView>().SetText("Not enough resources");
        }
    }
}
