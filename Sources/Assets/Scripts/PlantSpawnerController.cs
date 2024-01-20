using Unity.VisualScripting;
using UnityEngine;

public class PlantSpawnerController : MonoBehaviour
{
    public Transform spawner;
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
    }
}
