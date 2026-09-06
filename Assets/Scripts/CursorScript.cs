using UnityEngine;
using UnityEngine.InputSystem;

public class CursorScript : MonoBehaviour
{
    [SerializeField] private Texture2D normalCursor;
    [SerializeField] private Texture2D clickCursor;

    private void Awake()
    {
        SetNormalCursor();
    }

    private void Update()
    {
        if (Mouse.current == null)
            return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Cursor.SetCursor(clickCursor, Vector2.zero, CursorMode.ForceSoftware);
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            SetNormalCursor();
        }
    }

    private void SetNormalCursor()
    {
        Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
}