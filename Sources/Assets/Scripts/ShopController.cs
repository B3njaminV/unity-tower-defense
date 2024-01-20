using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    ///////////////////////////////////////////////////////////////
    /// SINGLETON
    ///////////////////////////////////////////////////////////////
    private static ShopController instance = null;
    public static ShopController Instance => instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }
    private ShopController() { }

    ///////////////////////////////////////////////////////////////
    
    [System.Serializable]
    public class PlantButton
    {
        public GameObject obj;
        public PlantEnum plant;
        public GameObject selectionMarker;
        [HideInInspector] public int price = 0;
    }

    [SerializeField]
    private PlantButton[] plantsButtons;

    [SerializeField]
    private ScenarioManager scenarioManager;

    public PlantButton selectedPlant { get; private set; }

    private void Start()
    {
        bool first = true;
        // activer uniquement les boutons des plantes du scenario :
        foreach (var up in scenarioManager.GetUsablePlants())
        {
            foreach (var pb in plantsButtons)
            {
                if (pb.plant.Equals(up.plant))
                {
                    pb.price = up.price;
                    pb.obj.GetComponentInChildren<Text>().text = pb.price.ToString();
                    pb.obj.SetActive(true);
                    pb.obj.GetComponent<Button>().onClick.AddListener(delegate { btnClick(pb); });
                    if (first)
                    {
                        first = false;
                        btnClick(pb);
                    }
                }
            }
        }
    }

    private void btnClick(PlantButton plantButton)
    {
        unSelectAllMarkers();
        plantButton.selectionMarker.gameObject.SetActive(true);
        selectedPlant = plantButton;
    }

    private void unSelectAllMarkers()
    {
        foreach(var p in plantsButtons)
        {
            p.selectionMarker.gameObject.SetActive(false);
        }
    }
}
