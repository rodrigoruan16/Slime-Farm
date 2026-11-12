using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [Header("Botão de som")]
    [SerializeField] private Image soundButtonImage;  // Image do SoundButton
    [SerializeField] private Sprite soundOnSprite;    // alto-falante normal
    [SerializeField] private Sprite soundOffSprite;   // alto-falante riscado

    private bool isMuted = false;

    public void MuteGame()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0f : 1f;

        if (soundButtonImage != null)
            soundButtonImage.sprite = isMuted ? soundOffSprite : soundOnSprite;
    }

    public void CloseGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}