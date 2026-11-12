using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private float lastUpdate;
    private GameObject slimes;
    private BigInteger money = 1000000000;
    private BigInteger maxSlimes = 10;
    private BigInteger powerClick = 1;
    private BigInteger autoClickQuantity = 0;
    private Dictionary<string, GameObject> slimePrefabs;
    private bool firstRareEgg = true;

    // Estatísticas usadas pelas conquistas
    private long totalClicks = 0;
    private BigInteger totalGooEarned = 0;
    private int upgradesBought = 0;
    private int slotsBought = 0;
    private int rareSlimesObtained = 0;

    // Slimes já descobertos (nome do prefab, ex.: "BlueSlime"). Usado pela enciclopédia.
    private HashSet<string> discoveredSlimes = new HashSet<string>();

    [SerializeField]
    private GameObject[] slimePrefabsList;
    private int quantitySpecialSlime = 3;
    private int quantityLeftToSpecialSlime = 9;

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

        // Slimes que já começam no prado (o verde inicial) contam como descobertos
        foreach (Transform child in slimes.transform)
        {
            discoveredSlimes.Add(CleanSlimeName(child.name));
        }
    }

    public BigInteger GetRemainingSlot()
    {
        return maxSlimes - slimes.transform.childCount;
    }

    public void IncreaseSlot()
    {
        maxSlimes += 10;
        slotsBought++;
        UpdateSlimeQuantityText();
    }

    private void UpdateSlimeQuantityText()
    {
        quantitySlimesText.text = "Slimes: " + slimes.transform.childCount + " / " + maxSlimes;
    }

    // Toda criação de slime passa por aqui, para registrar a descoberta
    private void SpawnSlime(GameObject prefab)
    {
        Instantiate(prefab, slimes.transform);
        discoveredSlimes.Add(prefab.name);
    }

    // "GreenSlime (1)" ou "GreenSlime(Clone)" -> "GreenSlime"
    private string CleanSlimeName(string name)
    {
        name = name.Replace("(Clone)", "");
        int index = name.IndexOf(" (");
        if (index >= 0)
            name = name.Substring(0, index);
        return name.Trim();
    }

    public bool IsSlimeDiscovered(string slimeName)
    {
        return discoveredSlimes.Contains(slimeName);
    }

    public void BuySlime(string slimeType)
    {
        SpawnSlime(slimePrefabs[slimeType]);
        UpdateSlimeQuantityText();
    }

    public void OpenRareEgg()
    {
        if (firstRareEgg)
        {
            int specialSlimeIndex = Random.Range(0, quantitySpecialSlime);
            SpawnSlime(slimePrefabsList[specialSlimeIndex]);
            firstRareEgg = false;
            rareSlimesObtained++;
            UpdateSlimeQuantityText();
            return;
        }

        if (quantityLeftToSpecialSlime <= 0)
        {
            int specialSlimeIndex = Random.Range(0, quantitySpecialSlime);
            SpawnSlime(slimePrefabsList[specialSlimeIndex]);
            quantityLeftToSpecialSlime = 9;
            rareSlimesObtained++;
            UpdateSlimeQuantityText();
            return;
        }

        int el = Random.Range(0, slimePrefabsList.Length);

        // Usuario conseguiu um slime especial
        if (el < quantitySpecialSlime)
        {
            quantityLeftToSpecialSlime = 9;
            rareSlimesObtained++;
        }
        else
        {
            quantityLeftToSpecialSlime--;
        }

        SpawnSlime(slimePrefabsList[el]);
        UpdateSlimeQuantityText();
    }

    public BigInteger GetMoneyPerClick(long baseValue)
    {
        return baseValue * powerClick + 2;
    }

    public int getQuantityLeftToSpecialSlime()
    {
        return quantityLeftToSpecialSlime;
    }

    public void updateAutoClick()
    {
        autoClickQuantity++;
        upgradesBought++;
    }

    public void updatePowerClick()
    {
        powerClick *= 2;
        upgradesBought++;
    }

    public BigInteger GetTotalMoney()
    {
        return money;
    }

    public void RemoveMoney(BigInteger amount)
    {
        money -= amount;
    }

    public void AddMoney(BigInteger amount)
    {
        money += amount;
        totalGooEarned += amount;
    }

    public void RegisterClick()
    {
        totalClicks++;
    }

    public long GetTotalClicks()
    {
        return totalClicks;
    }

    public BigInteger GetTotalGooEarned()
    {
        return totalGooEarned;
    }

    public int GetUpgradesBought()
    {
        return upgradesBought;
    }

    public int GetSlotsBought()
    {
        return slotsBought;
    }

    public int GetRareSlimesObtained()
    {
        return rareSlimesObtained;
    }

    public int GetSlimeCount()
    {
        return slimes.transform.childCount;
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
                    AddMoney(autoClickQuantity * slime.GetGooGenerated());
                }

                lastUpdate = Time.time;
            }
        }


        moneyText.text = "Goo: " + money.ToString();
    }
}