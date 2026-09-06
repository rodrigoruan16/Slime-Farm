using System.Linq;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    private Button button;
    private Image background;
    private GameManager gm;
    private BigInteger itemPrice;

    private Color activeColor = Color.white;
    private Color inactiveColor = Color.gray;
    private bool bought = false;
    private TMP_Text buttonText;
    private TMP_Text itemName;

    private AudioSource audioSource;

    private void Awake()
    {
        button = GetComponent<Button>();
        background = GetComponent<Image>();
        audioSource = transform.parent.GetComponent<AudioSource>();

        buttonText = button.transform
            .GetChild(0)
            .GetComponent<TMP_Text>();

        UpdateItemPrice();

        itemName = transform.parent.GetChild(1).GetComponent<TMP_Text>();

        button.onClick.AddListener(OnButtonClicked);
    }

    private void UpdateItemPrice()
    {
        itemPrice = BigInteger.Parse(buttonText.text.Split(" ")[0]);
    }

    private void Start()
    {
        gm = GameManager.Instance;
    }

    private void UpdateItemLevel()
    {
        if (itemName.text.Contains("Slime"))
            return;
        print(itemName.text);

        string[] splittedText = itemName.text.Split(" ");

        BigInteger level = BigInteger.Parse(splittedText[splittedText.Length - 1]);

        splittedText[splittedText.Length - 1] = (level + 1).ToString();

        itemName.text = string.Join(" ", splittedText);
    }

    private void OnButtonClicked()
    {
        if (gm.GetTotalMoney() >= itemPrice)
        {
            gm.RemoveMoney(itemPrice);

            Transform parent = transform.parent;

            if (parent.tag.Contains("Slime"))
            {
                gm.BuySlime(parent.tag);
                buttonText.text = (itemPrice + itemPrice / 2).ToString() + " Goo";
            }
            else if (parent.tag == "PowerClick")
            {
                gm.updatePowerClick();
                buttonText.text = (itemPrice * 4).ToString() + " Goo";
            }
            else if (parent.tag == "AutoClick")
            {
                gm.updateAutoClick();
                buttonText.text = (itemPrice * 10).ToString() + " Goo";
            }
            else if (parent.tag == "Slot")
            {
                gm.IncreaseSlot();
                buttonText.text = (itemPrice * 2).ToString() + " Goo";
            }
            else if (parent.tag == "RareEgg")
            {
                gm.OpenRareEgg();
                buttonText.text = (itemPrice * 2).ToString() + " Goo";
            }

            UpdateItemPrice();
            UpdateItemLevel();
            audioSource.Play();
        }
    }

    public void SetActive(bool active)
    {
        if (itemName.text.Contains("Slime") && gm.GetRemainingSlot() <= 0)
        {
            button.interactable = false;
            background.color = inactiveColor;
            return;
        }

        button.interactable = active && !bought;
        background.color = (active && !bought) ? activeColor : inactiveColor;
    }

    private void Update()
    {
        SetActive(gm.GetTotalMoney() >= itemPrice);
    }
}
