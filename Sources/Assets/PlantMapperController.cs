using UnityEngine;

public class PlantMapperController : MonoBehaviour
{

    public GameObject SunPlantPrefab;
    public GameObject GreenPlantPrefab;
    public GameObject PurplePlantPrefab;
    public GameObject RockPlantPrefab;

    public GameObject GetPlantPrefab(PlantEnum plantE)
    {
        switch (plantE)
        {
            case PlantEnum.Purple_plant: return PurplePlantPrefab;
            case PlantEnum.Green_plant: return GreenPlantPrefab;
            case PlantEnum.Rock_plant: return RockPlantPrefab;
            case PlantEnum.Sun_plant: return SunPlantPrefab;
            default: return null;
        }
    }

}
