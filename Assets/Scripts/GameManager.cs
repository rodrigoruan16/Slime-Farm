using System.Numerics;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private float lastMoneyUpdate;
    private GameObject slimes;
    private BigInteger money = 0;
    private BigInteger moneyPerClick = 1;
    TMP_Text moneyText;
    void Awake()
    {
        Instance = this;
        slimes = GameObject.FindGameObjectWithTag("Slimes");
        moneyText = GameObject.FindGameObjectWithTag("MoneyText").GetComponent<TMP_Text>();
    }

    public BigInteger GetMoneyPerClick()
    {
        return moneyPerClick;
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
        // if (Time.time - lastMoneyUpdate >= 1f)
        // {
        //     money += slimes.transform.childCount;
        //     lastMoneyUpdate = Time.time;
        // }
        moneyText.text = "Goo: " + money.ToString();
    }
}
