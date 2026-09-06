using UnityEngine;
using UnityEngine.InputSystem;

public class ShopScript : MonoBehaviour
{
    [SerializeField]
    private GameObject shopPanel;

    void Awake()
    {
        shopPanel.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            shopPanel.SetActive(!shopPanel.activeSelf);
        }
    }
}
