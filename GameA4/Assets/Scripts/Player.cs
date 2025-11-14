using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("基本ステータス")]
    [SerializeField] int currentHp;   //現在のHP
    [SerializeField] float speed; //移動速度
    public int jumpCount;
    public int maxJumpCount;
    public float jumpForce; //ジャンプの高さ
    

    [Header("状態")]
    public bool Alive; //生きてるかどうか
    public bool isGrounded; //地面についているか
    public bool pause;


    public enum State//今の状態
    {
        None,
        Moved,
        Dead,
    }
    public State state;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHp = 1;
        Alive = true;
        isGrounded = false;
        state = State.None;
    }
    // Update is called once per frame
    void Update()
    {
        LifeCheck();
        if (!pause)  // 一時停止処理
        {
            if (Alive)  // 生きているときだけ移動とジャンプを処理
            {
                PlayerMove();
                Jump();
            }
            else
            {
                speed = 0f;
                rb.velocity = new Vector2(0, 0);  // 移動を停止
            }
        }
    }

    float posX = 0;
    //Player操作処理
    private void PlayerMove()
    {
        var leftKey = KeyCode.A;
        var rightKey = KeyCode.D;
        

        if (Alive)
        {
            rb.velocity = new Vector2(posX, rb.velocity.y);

            if (Input.GetKey(leftKey) && !Input.GetKey(rightKey))
            {
                posX = -speed;
                state = State.Moved;
            }
            else if (Input.GetKey(rightKey) && !Input.GetKey(leftKey))
            {
                posX = speed;
                state = State.Moved;
            }
            else
            {
                if (isGrounded)
                {
                    posX = 0;
                    state = State.None;
                }
            }
        }


    }

    public void Jump()　//ジャンプ
    {
        var upKey = KeyCode.Space;

        if (jumpCount >= 1 || isGrounded) // 飛べる回数が0以上の時
        {
            if (Input.GetKeyDown(upKey))
            {
                jumpCount -= 1;
                isGrounded = false;
                state = State.Moved;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }

    


    public void HitGround()
    {
        rb.velocity = new Vector2(posX, rb.velocity.y);
        isGrounded = true;
        jumpCount = maxJumpCount;
    }

    public void TakeDamage(int damageAmount)　//ダメージ判定
    {
        currentHp -= damageAmount;

        if (currentHp <= 0 && Alive)　//現在のHPが０以下になった時
        {
            currentHp = 0;
            Alive = false;
        }
        else if (!Alive)
        {
            currentHp = 0;
        }
    }

    [SerializeField] float deadP = 25;

    void LifeCheck()
    {
        Vector2 pos = transform.position;

        if (pos.y < -deadP)
        {
            if (Alive)
            {
                currentHp = 0;
                Alive = false;
                state = State.Dead;
            }
        }


        if (currentHp <= 0 && Alive)
        {
            currentHp = 0;
            Alive = false;
            state = State.Dead;
        }
    }
}
