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

    public GameObject[] signalLight;

    void Start()
    {
        colors = Colors.Blue;
        GetComponent<SpriteRenderer>().color = Color.green;
        timer = 0f;
    }

    public float ctimer = 10f;

    void Update()
    {
        
        timer += Time.deltaTime;
        if(timer >= ctimer)
        {
            timer = 0f;
            switch(colors)
            {
                case Colors.Red:
                    signalLight[0].GetComponent<SpriteRenderer>().color = Color.green;
                    signalLight[1].GetComponent<SpriteRenderer>().color = Color.black;
                    signalLight[2].GetComponent<SpriteRenderer>().color = Color.black;
                    colors = 0;
                    ctimer = 10f;
                    break;
                case Colors.Yellow:
                    signalLight[0].GetComponent<SpriteRenderer>().color = Color.black;
                    signalLight[1].GetComponent<SpriteRenderer>().color = Color.black;
                    signalLight[2].GetComponent<SpriteRenderer>().color = Color.red;
                    colors++;
                    ctimer = 7f;
                    break;
                case Colors.Blue:
                    signalLight[0].GetComponent<SpriteRenderer>().color = Color.black;
                    signalLight[1].GetComponent<SpriteRenderer>().color = Color.yellow;
                    signalLight[2].GetComponent<SpriteRenderer>().color = Color.black;
                    colors++;
                    ctimer = 1f;
                    break;
            }
        }
    }
}
