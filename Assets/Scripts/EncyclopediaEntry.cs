using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Vai no objeto raiz de cada item da enciclopédia (EncyclopediaItem).
// Enquanto o slime não for descoberto, mostra silhueta e "???".
// Quando o jogador consegue o slime (compra ou ovo), revela e libera o resgate.
public class EncyclopediaEntry : MonoBehaviour
{
    [Header("Slime")]
    [SerializeField] private GameObject slimePrefab;   // prefab em Assets/Characters
    [SerializeField] private string displayName;
    [SerializeField, TextArea(2, 4)] private string description;
    [SerializeField] private long reward = 500;

    [Header("Imagens")]
    [Tooltip("Opcional. Se vazio, usa a sprite do próprio prefab do slime.")]
    [SerializeField] private Sprite revealedSprite;
    [SerializeField] private Sprite lockedSprite;       // silhueta

    private Image icon;
    private TMP_Text nameText;
    private TMP_Text descriptionText;
    private Button getButton;
    private Image getButtonBackground;
    private TMP_Text getButtonText;
    private AudioSource audioSource;
    private GameManager gm;

    private Color activeColor = Color.white;
    private Color inactiveColor = Color.gray;

    private bool revealed = false;
    private bool claimed = false;

    private void Awake()
    {
        icon = transform.Find("Icon").GetComponent<Image>();
        nameText = transform.Find("NameText").GetComponent<TMP_Text>();
        descriptionText = transform.Find("DescriptionText").GetComponent<TMP_Text>();

        Transform buttonTransform = transform.Find("GetButton");
        getButton = buttonTransform.GetComponent<Button>();
        getButtonBackground = buttonTransform.GetComponent<Image>();
        getButtonText = buttonTransform.GetChild(0).GetComponent<TMP_Text>();

        audioSource = GetComponent<AudioSource>();

        if (revealedSprite == null && slimePrefab != null)
        {
            SpriteRenderer sr = slimePrefab.GetComponent<SpriteRenderer>();
            if (sr != null)
                revealedSprite = sr.sprite;
        }

        getButton.onClick.AddListener(Claim);
        ShowLocked();
    }

    private void Start()
    {
        gm = GameManager.Instance;
    }

    private void Update()
    {
        if (revealed || slimePrefab == null)
            return;

        if (gm.IsSlimeDiscovered(slimePrefab.name))
            Reveal();
    }

    private void ShowLocked()
    {
        icon.sprite = lockedSprite;
        nameText.text = "???";
        descriptionText.text = "???";

        getButton.interactable = false;
        getButtonBackground.color = inactiveColor;
        getButtonText.text = "Bloqueado";
    }

    private void Reveal()
    {
        revealed = true;

        icon.sprite = revealedSprite;
        nameText.text = displayName;
        descriptionText.text = description;

        getButton.interactable = true;
        getButtonBackground.color = activeColor;
        getButtonText.text = "Resgatar " + reward + " Goo";
    }

    private void Claim()
    {
        if (!revealed || claimed)
            return;

        claimed = true;
        gm.AddMoney(reward);

        getButton.interactable = false;
        getButtonBackground.color = inactiveColor;
        getButtonText.text = "Resgatado";

        if (audioSource != null)
            audioSource.Play();
    }
}