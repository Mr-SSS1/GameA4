using UnityEngine;

public class Obj : MonoBehaviour
{
    Vector2 defPos;
    bool set;
    [SerializeField] Player player;

    void Start()
    {
        set = true;
        defPos = transform.position;
    }

    void Update()
    {
        float distX = Mathf.Abs(player.transform.position.x - transform.position.x);

        // プレイヤーが近くに来たらセット解除（リセット準備）
        if (distX < 5f)
        {
            set = false;
        }

        // 離れたらリセット
        if (distX > 15f && !set)
        {
            ResetPos();
            set = true;
        }

        // 初期位置からのズレで強制リセットする場合
        float diffFromDefault = Mathf.Abs(defPos.x - transform.position.x);
        if (diffFromDefault > 10f)
        {
            ResetPos();
        }
    }

    void ResetPos()
    {
        transform.position = defPos;
    }
}
