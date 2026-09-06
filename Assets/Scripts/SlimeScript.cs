using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    private float last_move;
    private Rigidbody2D _rb;
    private SpriteRenderer spriteRenderer;
    private bool right_direction = true;
    private GameManager gm;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        gm.AddMoney(gm.GetMoneyPerClick(100));
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = GameManager.Instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        right_direction = !right_direction;
    }

    void Action()
    {
        spriteRenderer.flipX = !right_direction;
        _rb.linearVelocity = new Vector2((right_direction ? 1 : -1) * 1.1f, _rb.linearVelocity.y);
    }

    void FixedUpdate()
    {
        if (Time.time - last_move >= 0.2f)
        {
            Action();
            last_move = Time.time;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
