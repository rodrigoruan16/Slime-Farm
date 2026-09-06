using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private float lastUpdate;
    private GameObject slimes;
    private BigInteger money = 0;
    private BigInteger maxSlimes = 10;
    private BigInteger powerClick = 1;
    private BigInteger autoClickQuantity = 0;
    private Dictionary<string, GameObject> slimePrefabs;

    private bool firstRareEgg = true;

    [SerializeField]
    private GameObject[] slimePrefabsList;

    TMP_Text moneyText;
    TMP_Text quantitySlimesText;
    void Awake()
    {
        Instance = this;
        slimes = GameObject.FindGameObjectWithTag("Slimes");
        moneyText = GameObject.FindGameObjectWithTag("MoneyText").GetComponent<TMP_Text>();
        quantitySlimesText = GameObject.FindGameObjectWithTag("QuantitySlimeText").GetComponent<TMP_Text>();

        slimePrefabs = new Dictionary<string, GameObject>();
        foreach (GameObject slime in slimePrefabsList)
        {
            slimePrefabs.Add(slime.name + "Item", slime);
        }
    }

    public BigInteger GetRemainingSlot()
    {
        return maxSlimes - slimes.transform.childCount;
    }

    public void IncreaseSlot()
    {
        maxSlimes += 10;
        UpdateSlimeQuantityText();
    }

    private void UpdateSlimeQuantityText()
    {
        quantitySlimesText.text = "Slimes: " + slimes.transform.childCount + " / " + maxSlimes;
    }

    public void BuySlime(string slimeType)
    {
        Instantiate(slimePrefabs[slimeType], slimes.transform);
        UpdateSlimeQuantityText();
    }

    public void OpenRareEgg()
    {
        if (firstRareEgg)
        {
            Instantiate(slimePrefabsList[0], slimes.transform);
            firstRareEgg = false;
            return;
        }

        int el = Random.Range(0, slimePrefabsList.Length);
        Instantiate(slimePrefabsList[el], slimes.transform);
    }

    public BigInteger GetMoneyPerClick(long baseValue)
    {
        return baseValue * powerClick + 200;
    }

    public void updateAutoClick()
    {
        autoClickQuantity++;
    }

    public void updatePowerClick()
    {
        powerClick *= 2;
    }

    public BigInteger GetTotalMoney()
    {
        return money;
    }

    public void RemoveMoney(BigInteger amount)
    {
        money -= amount;
    }

    public void AddMoney(BigInteger moneyPerClick)
    {
        money += moneyPerClick;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Do it when buy auto farm
        if (autoClickQuantity > 0)
        {
            if (Time.time - lastUpdate >= 1f)
            {
                foreach (Transform child in slimes.transform)
                {
                    SlimeScript slime = child.GetComponent<SlimeScript>();
                    money += autoClickQuantity * slime.GetGooGenerated();
                }

                lastUpdate = Time.time;
            }
        }


        moneyText.text = "Goo: " + money.ToString();
    }
}
