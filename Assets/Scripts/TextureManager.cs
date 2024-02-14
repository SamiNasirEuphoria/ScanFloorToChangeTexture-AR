using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class TextureManager : MonoBehaviour
{
    public ARPlaneManager arPlanManager;
    public Material blue, brown;
    public Button brownButton, blueButton;
    private void Start()
    {
        brownButton.onClick.AddListener(ChangeTextureToBrown);
        blueButton.onClick.AddListener(ChangeTextureToBlue);
    }
    public void ChangeTextureToBlue()
    {
        arPlanManager.planePrefab.GetComponent<MeshRenderer>().material = blue;
        GetContent(blue);
    }
    public void ChangeTextureToBrown()
    {
        arPlanManager.planePrefab.GetComponent<MeshRenderer>().material = brown;
        GetContent(brown);
    }
    public void GetContent(Material setMaterial)
    {
        GameObject sample = GameObject.Find("Trackables");
        var count = sample.transform.GetChildCount();
        for (int i=0; i< count; i++)
        {
            sample.transform.GetChild(i).GetComponent<MeshRenderer>().material = setMaterial;
        }
    }
}
