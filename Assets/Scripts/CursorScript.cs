using UnityEngine;
using UnityEngine.InputSystem;

public class CursorScript : MonoBehaviour
{
    [SerializeField]
    private Texture2D normalCursor;

    [SerializeField]
    private Texture2D clickCursor;

    void Awake()
    {
        Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void OnClick()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
            Cursor.SetCursor(clickCursor, Vector2.zero, CursorMode.Auto);

        if (Mouse.current.leftButton.wasReleasedThisFrame)
            Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);

    }

    // Update is called once per frame
    void Update()
    {
        OnClick();
    }
}
