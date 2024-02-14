using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;

public class TextureManager : MonoBehaviour
{
    public ARPlaneManager arPlanManager;
    public GameObject planePrefabBlue,PlanePrefabBrown;
    public Material blue, brown;
    public Button brownButton, blueButton;
    public string sceneName;
    static int num;
    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        if (num == 1)
        {
            arPlanManager.planePrefab = planePrefabBlue;
        }
        else if (num == 0)
        {
            arPlanManager.planePrefab = PlanePrefabBrown;
        }
        brownButton.onClick.AddListener(ChangeTextureToBrown);
        blueButton.onClick.AddListener(ChangeTextureToBlue);
    }
    public void ChangeTextureToBlue()
    {
        arPlanManager.planePrefab = planePrefabBlue;
        num = 1;
        ReloadScene(sceneName);
        //arPlanManager.planePrefab.GetComponent<MeshRenderer>().material = blue;
        //GetContent(blue);
    }
    public void ChangeTextureToBrown()
    {
        arPlanManager.planePrefab = PlanePrefabBrown;
        num = 0;
        ReloadScene(sceneName);
        //arPlanManager.planePrefab.GetComponent<MeshRenderer>().material = brown;
        //GetContent(brown);
    }
    public void GetContent(Material setMaterial)
    {
        GameObject sample = GameObject.Find("Trackables");
        var count = sample.transform.childCount;
        for (int i=0; i< count; i++)
        {
            sample.transform.GetChild(i).GetComponent<MeshRenderer>().material = setMaterial;
        }
    }
    public void ReloadScene(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }
}
