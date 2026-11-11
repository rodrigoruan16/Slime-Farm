using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RedeemButton : MonoBehaviour
{
    private Button button;
    private Image background;
    private GameManager gm;
    private BigInteger itemPrice;

    private Color activeColor = Color.white;
    private Color inactiveColor = Color.gray;
    private bool bought = false;
    private TMP_Text buttonText;

    private AudioSource audioSource;

    private void Awake()
    {
        button = GetComponent<Button>();
        background = GetComponent<Image>();
        audioSource = transform.parent.GetComponent<AudioSource>();

        buttonText = button.transform
            .GetChild(0)
            .GetComponent<TMP_Text>();

        button.onClick.AddListener(OnButtonClicked);
    }
    private void Start()
    {
        gm = GameManager.Instance;
    }

    private void OnButtonClicked()
    {

        BigInteger moneyToRedeem = BigInteger.Parse(buttonText.text.Split(" ")[1]);
        gm.AddMoney(moneyToRedeem);
        button.interactable = false;
        buttonText.text = "Resgatado";
        audioSource.Play();
    }

}
