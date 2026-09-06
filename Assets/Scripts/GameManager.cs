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
    private BigInteger moneyPerClick = 1;
    private BigInteger powerClick = 1;
    private BigInteger autoClickQuantity = 0;
    private Dictionary<string, GameObject> slimePrefabs;

    [SerializeField]
    private GameObject[] slimePrefabsList;

    TMP_Text moneyText;
    void Awake()
    {
        Instance = this;
        slimes = GameObject.FindGameObjectWithTag("Slimes");
        moneyText = GameObject.FindGameObjectWithTag("MoneyText").GetComponent<TMP_Text>();

        slimePrefabs = new Dictionary<string, GameObject>();
        foreach (GameObject slime in slimePrefabsList)
        {
            slimePrefabs.Add(slime.name + "Item", slime);
        }
    }

    public void BuySlime(string slimeType)
    {
        print(slimeType);
        Instantiate(slimePrefabs[slimeType], slimes.transform);
    }

    public BigInteger GetMoneyPerClick(long baseValue)
    {
        return baseValue * powerClick;
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
