using UnityEngine;
using UnityEngine.InputSystem;

public class PanelScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] panels;

    public void OpenPanel(GameObject panelToOpen)
    {
        if (panelToOpen.activeSelf)
        {
            panelToOpen.SetActive(false);
            return;
        }

        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        panelToOpen.SetActive(!panelToOpen.activeSelf);
    }

    void Awake()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}
