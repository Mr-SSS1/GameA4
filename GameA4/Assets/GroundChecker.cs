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
            Debug.Log("ínñ Ç∆ê⁄êGÇµÇΩÅI");
            player.HitGround();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
