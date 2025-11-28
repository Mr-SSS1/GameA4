using UnityEngine;


public class GroundChecker : MonoBehaviour
{
    Player player;
    public GameManeger gm;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && !player.isGrounded)
        {
            Debug.Log("地面と接触した！");
            player.HitGround();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CheckPoint")
        {
            Debug.Log("確認地点と接触した！");
            player.ResPos = new Vector2(collision.transform.position.x, collision.transform.position.y + 2);
        }
        else if(collision.tag == "GoalPoint")
        {
            if (!gm.Goal)
            {
                Debug.Log("ゴール地点と接触した！");
                gm.Goal = true;
            } 
        }
    }
}
