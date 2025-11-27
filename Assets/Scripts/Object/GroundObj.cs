using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObj : MonoBehaviour
{
    public float amplitude;  // óhÇÍïù
    public float speed;       // óhÇÍÇÈë¨Ç≥

    enum MoveType
    {
        X,
        Y,
    }
    [SerializeField]MoveType mType;

    private Vector2 startPos;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * amplitude;

        switch (mType)
        {
            case MoveType.X:
                rb.velocity = new Vector2(offset, rb.velocity.y);
                break;
            case MoveType.Y:
                rb.velocity = new Vector2(rb.velocity.x, offset);
                break;
        }
        
    }
}
