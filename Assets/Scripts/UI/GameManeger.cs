using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    [SerializeField] Player p;
    [SerializeField] Text deathCounter;
    [SerializeField] Text timerText;
    public bool Goal;
    float timer;

    [Header("goal画面")]
    [SerializeField] GameObject panel;
    [SerializeField] Text panelTex;

    private void Start()
    {
        timer = 0;
        Goal = false;
        panel.SetActive(false);
    }
    int d;
    private void Update()
    {
        if (!Goal)
        {
            panel.SetActive(false);
            TimerCount();
        }
        else
        {
            panel.SetActive(true);
            panelTex.text = "ゲームクリア\nクリアタイム　" + timer.ToString("F1") + $"\n死亡回数{d}";
        }
        
    }

    void TimerCount() 
    {
        timer += Time.deltaTime;
        timerText.text = "Time : " + timer.ToString("F1");
    
    }

    public void DeathCount(int Count)
    {
        deathCounter.text = $"死亡回数：{Count}回";
        d = Count;
    }
}
