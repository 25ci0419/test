using UnityEngine;

public class Diel : MonoBehaviour
{
    public
    int Cardtes = 0;//ディーラーのカード数値(庄家牌的点数)
    int DielSet = 0;//ディーラーの行動制御(经销商行为管控)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (DielSet == 0)//一番最初に動く(首先采取行动)
        {//カードを2枚引き最初の1枚を公開する(抽两张牌，并展示第一张)
            for (int x = 0; x < 2; x++)
            {
                int Cardown = Random.Range(1, 10);
                Cardtes += Cardown;
                if (x == 1)
                {
                    Debug.Log(Cardtes);
                }
            }
            DielSet = 100;//ディーラー初動終了を報告(报告了经销商初步推广工作的完成情况)
        }
        else if (Cardtes < 16 && DielSet == 300)
        {
                int Cardown = Random.Range(1, 10);//テストシャッフルシステム(测试随机排序系统)
            Cardtes += Cardown;
                Debug.Log(Cardtes + "追撃");//16より下なら引き続けるがバーストしたら引かない(如果点数总和为16或更低，我会继续要牌，但如果会导致爆牌，我就不会要牌)
            if (Cardtes >= 22)//バーストシステム(爆发系统)
            {//22以上になることで強制的に行動終了状態とプレーヤーカード数値を0にする。(总和超过 22 会导致回合结束，并将玩家的卡牌点数重置为 0)
                Debug.Log("バースト");
                DielSet = 400;
                Cardtes = 0;
            }
            if (Cardtes >= 16)//16以上になることで終了(当数值达到 16 或更高时结束)
            {//全行動が終了したことを報告(报告所有活动已完成)
                DielSet = 400;
                Debug.Log("終了");
            }
        }
        if (DielSet == 400)//勝敗システムへ(进入胜负系统)
        {
            GameObject ALL = GameObject.Find("systemall");
            ALL.GetComponent<ave>().avelazi();
        }
        if (DielSet == 100)//プレーヤーの行動を開始できるようにする(使玩家能够发起行动)
        {
            GameObject Hitten = GameObject.Find("system");
            Hitten.GetComponent<Hit>().HitReady();
            DielSet = 200;
        }
    }
    
    public void DielReady()//プレーヤーの全行動終了を確認(确认所有玩家操作均已完成)
    {
        if (DielSet == 200)
        {
            Debug.Log("ディーラースタート");
            Debug.Log(Cardtes);
            DielSet = 300 ;
        }
    }
}
