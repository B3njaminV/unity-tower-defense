using Unity.VisualScripting;
using UnityEngine;

public class PlantSpawnerController : MonoBehaviour
{
    public Transform spawner;
    private PlantMapperController mapper;
    
    private GameObject currentPlant = null;

    private void Start()
    {
        mapper = GameObject.FindGameObjectWithTag("PlantMapper").gameObject.GetComponent<PlantMapperController>();
    }

    public void onClick()
    {
        if(currentPlant == null)
        {
            currentPlant = Instantiate(mapper.GetPlantPrefab(ShopController.Instance.selectedPlant.plant), spawner);
        }
    }
}
