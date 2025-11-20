using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP : MonoBehaviour
{
    [SerializeField] Transform Wp;
    [SerializeField] Player player;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.transform.position = new Vector2(Wp.position.x + 3, Wp.position.y + 2);
        }
    }

}
