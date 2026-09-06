using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    private float last_move;
    private Rigidbody2D _rb;
    private SpriteRenderer spriteRenderer;
    private bool right_direction = true;
    private GameManager gm;

    [SerializeField]
    private long gooGenerated;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public long GetGooGenerated()
    {
        return gooGenerated;
    }

    private void OnMouseDown()
    {
        gm.AddMoney(gm.GetMoneyPerClick(gooGenerated));
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = GameManager.Instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Wall")
            right_direction = !right_direction;
    }

    void Action()
    {
        spriteRenderer.flipX = !right_direction;
        _rb.linearVelocity = new Vector2((right_direction ? 1 : -1) * Random.Range(1f, 2f), _rb.linearVelocity.y);
    }

    void FixedUpdate()
    {
        Action();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
