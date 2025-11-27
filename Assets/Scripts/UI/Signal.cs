using UnityEngine;

public class Signal : MonoBehaviour
{
    [SerializeField]float timer;

    public enum Colors
    {
        Blue,
        Yellow,
        Red,
    }
    public Colors colors;

    [SerializeField] GameObject[] signalLight;

    void Start()
    {
        colors = Colors.Blue;
        signalLight[0].GetComponent<SpriteRenderer>().color = Color.green;
        signalLight[1].GetComponent<SpriteRenderer>().color = Color.gray;
        signalLight[2].GetComponent<SpriteRenderer>().color = Color.gray;

        timer = 0f;
    }

    public float ctimer = 10f;

    void Update()
    {

        ChangeSignal();
    }

    void ChangeSignal()
    {
        timer += Time.deltaTime;
        if (timer >= ctimer)
        {
            timer = 0f;

            colors++;
            if(colors > Colors.Red)
            {
                colors = 0;
            }
        }

        switch (colors)
        {
            case Colors.Red:
                signalLight[0].GetComponent<SpriteRenderer>().color = Color.gray;
                signalLight[1].GetComponent<SpriteRenderer>().color = Color.gray;
                signalLight[2].GetComponent<SpriteRenderer>().color = Color.red;
                ctimer = 6f;
                break;
            case Colors.Yellow:
                signalLight[0].GetComponent<SpriteRenderer>().color = Color.gray;
                signalLight[1].GetComponent<SpriteRenderer>().color = Color.yellow;
                signalLight[2].GetComponent<SpriteRenderer>().color = Color.gray;
                ctimer = 2f;
                break;
            case Colors.Blue:
                signalLight[0].GetComponent<SpriteRenderer>().color = Color.green;
                signalLight[1].GetComponent<SpriteRenderer>().color = Color.grey;
                signalLight[2].GetComponent<SpriteRenderer>().color = Color.gray;
                ctimer = 10f;
                break;
        }
    }

    public void ResetSignal()
    {
        timer = 0f;
        colors = 0;
    }
}
