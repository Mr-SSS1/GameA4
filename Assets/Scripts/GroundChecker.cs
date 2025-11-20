using UnityEngine;


public class GroundChecker : MonoBehaviour
{
    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            Debug.Log("地面と接触した！");
            player.HitGround();
        }
        else if(collision.tag == "CheckPoint") 
        {
            Debug.Log("確認地点と接触した！");
            player.ResPos = new Vector2(collision.transform.position.x, collision.transform.position.y + 2);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
