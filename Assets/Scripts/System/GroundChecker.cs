using UnityEngine;
using UnityEngine.UI;


public class GroundChecker : MonoBehaviour
{
    Player player;
    public GameManeger gm;
    public Text CpText;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        cptime = 0f;
    }

    void Update()
    {
        if (cptime > 0f)
        {
            CpText.text = $"CheckPoint";
            cptime -= 1f * Time.deltaTime;
        }
        else
        {
            CpText.text = $"";
            cptime = 0f;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && !player.isGrounded)
        {
            Debug.Log("地面と接触した！");
            player.HitGround();
        }
    }
    float cptime;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CheckPoint")
        {
            Debug.Log("確認地点と接触した！");
            player.ResPos = new Vector2(collision.transform.position.x, collision.transform.position.y + 2);
            cptime = 1f; 
        }
        else if (collision.tag == "GoalPoint")
        {
            if (!gm.Goal)
            {
                Debug.Log("ゴール地点と接触した！");
                gm.Goal = true;
            } 
        }
    }
}
