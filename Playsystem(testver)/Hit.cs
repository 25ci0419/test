using UnityEngine;
using UnityEngine.Timeline;

public class Hit : MonoBehaviour
{
    public
    int Cardpoint = 0;//プレーヤーのカード数値(玩家卡面值)
    int Playset = 0;//プレーヤーの行動制御(玩家动作控制)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;//フレームレート制御(帧率控制)
    }

    // Update is called once per frame
    void Update()
    {
        if (Playset == 100)
        {//初動の動きでもある2枚カードを引くこと(抽两张牌，这也是一个初始动作)
            for (int x = 0; x < 2; x++)
            {
                int Cardon = Random.Range(1, 10);//テストシャッフルシステム(测试随机排序系统)
                Cardpoint += Cardon;
                Debug.Log(Cardpoint);
            }
            Playset = 200;//キー入力状態へ(切换到按键输入模式)
            Debug.Log("スタート");
        }
        else if (Cardpoint <= 21 && Playset == 200)
        {
            if (Input.GetKeyDown(KeyCode.Space))//ヒットシステム(命中系统)
            {//カードを1枚引く(抽一张牌)
                int Cardon= Random.Range(1, 10);
                Cardpoint += Cardon;
                Debug.Log(Cardpoint + "ヒット");
            }
            if (Input.GetKeyDown(KeyCode.B))//ダブルアップシステム(加倍系统)
            {//カードを1枚引き、プログラム設定はまだしていないが掛け金が2倍になる 使用後は行動終了状態になる(抽一张牌；赌注翻倍（即使尚未配置程序设置）。使用后，您将进入“动作完成”状态。)
                int Cardon = Random.Range(1, 10);
                Cardpoint += Cardon;
                Playset = 300;
                Debug.Log(Cardpoint + "ダブルアップ");
            }
            if (Cardpoint >= 22)//バーストシステム(爆发系统)
            {//22以上になることで強制的に行動終了状態とプレーヤーカード数値を0にする。(总和超过 22 会导致回合结束，并将玩家的卡牌点数重置为 0)
                Debug.Log("バースト");
                Playset = 300;
                Cardpoint = 0;
            }
            if (Input.GetKeyDown(KeyCode.V))//スタンドシステム(看台系统)
            {//行動終了状態になる(进入动作完成状态)
                Playset = 300;
                Debug.Log("スタンド");
            }
        }
        if (Playset == 300)//行動終了情報をゲームシステムに転送(将动作完成信息传输给游戏系​​统)
        {
            GameObject ALL = GameObject.Find("systemall");
            ALL.GetComponent<ave>().HitSet();
        }
    }
    public void HitReady()//プレーヤーの開始制御(播放器播放控制)
    {
        if (Playset == 0)
        {
            Playset = 100;
            Debug.Log("プレーヤースタート");
        }
    }
}
