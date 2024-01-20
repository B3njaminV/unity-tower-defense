using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [System.Serializable]
    public class PlantButton
    {
        public GameObject obj;
        public PlantEnum plant;
        public GameObject selectionMarker;
    }

    [SerializeField]
    private PlantButton[] plantsButtons;

    [SerializeField]
    private ScenarioManager scenarioManager;

    public PlantEnum selectedPlant { get; private set; }

    private void Start()
    {
        // activer uniquement les boutons des plantes du scenario :
        foreach( var up in scenarioManager.GetUsablePlants())
        {
            foreach ( var pb in plantsButtons)
            {
                if (pb.plant.Equals(up.plant))
                {
                    pb.obj.GetComponentInChildren<Text>().text = up.price.ToString();
                    pb.obj.SetActive(true);
                    pb.obj.GetComponent<Button>().onClick.AddListener(delegate { btnClick(pb); });
                }
            }
        }

        if (plantsButtons.Length > 0)
        {
            btnClick(plantsButtons[0]);
        }
    }

    private void btnClick(PlantButton plantButton)
    {
        unSelectAllMarkers();
        plantButton.selectionMarker.gameObject.SetActive(true);
        selectedPlant = plantButton.plant;
    }

    private void unSelectAllMarkers()
    {
        foreach(var p in plantsButtons)
        {
            p.selectionMarker.gameObject.SetActive(false);
        }
    }
}
