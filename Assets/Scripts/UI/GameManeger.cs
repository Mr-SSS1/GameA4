using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    [SerializeField] Player p;
    [SerializeField] Text deathCounter;
    [SerializeField] Text timerText;

    float timer;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        TimerCount();
    }

    void TimerCount() 
    {
        timer += Time.deltaTime;
        timerText.text = "Time : " + timer.ToString("F1");
    
    }

    public void DeathCount(int Count)
    {
        deathCounter.text = $"€–S‰ñ”F{Count}‰ñ";
    }
}
