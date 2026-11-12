using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// O que cada conquista mede. Para criar um tipo novo, adicione aqui
// e trate no switch de GetProgress().
public enum AchievementType
{
    Cliques,          // total de cliques em slimes
    GooAcumulado,     // total de Goo ganho no jogo (gastar não diminui)
    QuantidadeSlimes, // slimes no prado neste momento
    Upgrades,         // compras de Power Clique + Auto Clique
    SlotsComprados,   // vezes que comprou mais slots
    SlimesRaros       // slimes especiais obtidos no ovo raro
}

public class AchievementButton : MonoBehaviour
{
    [SerializeField] private AchievementType type;
    [SerializeField] private long target = 1;    // meta para completar
    [SerializeField] private long reward = 100;  // Goo dado ao resgatar

    private Button button;
    private Image background;
    private TMP_Text buttonText;
    private AudioSource audioSource;
    private GameManager gm;

    private Color activeColor = Color.white;
    private Color inactiveColor = Color.gray;
    private bool claimed = false;

    private void Awake()
    {
        button = GetComponent<Button>();
        background = GetComponent<Image>();
        audioSource = transform.parent.GetComponent<AudioSource>();
        buttonText = transform.GetChild(0).GetComponent<TMP_Text>();

        button.onClick.AddListener(Claim);
    }

    private void Start()
    {
        gm = GameManager.Instance;
    }

    private BigInteger GetProgress()
    {
        switch (type)
        {
            case AchievementType.Cliques:
                return gm.GetTotalClicks();
            case AchievementType.GooAcumulado:
                return gm.GetTotalGooEarned();
            case AchievementType.QuantidadeSlimes:
                return gm.GetSlimeCount();
            case AchievementType.Upgrades:
                return gm.GetUpgradesBought();
            case AchievementType.SlotsComprados:
                return gm.GetSlotsBought();
            case AchievementType.SlimesRaros:
                return gm.GetRareSlimesObtained();
            default:
                return 0;
        }
    }

    private bool IsCompleted()
    {
        return GetProgress() >= target;
    }

    private void Update()
    {
        if (claimed)
            return;

        bool completed = IsCompleted();

        button.interactable = completed;
        background.color = completed ? activeColor : inactiveColor;

        // Bloqueada: mostra o progresso (ex.: "37/100").
        // Completa: mostra a recompensa para resgatar.
        string text = completed
            ? "+" + reward + " Goo"
            : BigInteger.Min(GetProgress(), target) + "/" + target;

        if (buttonText.text != text)
            buttonText.text = text;
    }

    private void Claim()
    {
        if (claimed || !IsCompleted())
            return;

        claimed = true;
        gm.AddMoney(reward);

        button.interactable = false;
        background.color = inactiveColor;
        buttonText.text = "Resgatado";

        if (audioSource != null)
            audioSource.Play();
    }
}