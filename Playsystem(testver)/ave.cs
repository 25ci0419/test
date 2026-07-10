using UnityEngine;

public class ave : MonoBehaviour
{
    int DielSettap = 0;//ディーラー開始制御(发牌员启动控制)
    public GameObject Diell;
    public GameObject Play1;
    public Hit hit;
    public Diel diel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void HitSet()//プレーヤー全員が行動終了状態を確認できた場合、ディーラーを動かすことができる(一旦所有玩家都确认了“行动完成”状态，即可移动庄家标志)
    {
        DielSettap++;
        if (DielSettap == 1)
        {
            Diell.GetComponent<Diel>().DielReady();
        }
    }

    public void avelazi()//勝敗(胜负)
    {
        if (hit.Cardpoint > diel.Cardtes)//プレーヤーのカード数値がディーラーより上ならプレーヤーの勝ち(如果玩家的牌点数高于庄家，玩家获胜)
        {
            Debug.Log("プレーヤーの勝ち");
        }
        else if (hit.Cardpoint < diel.Cardtes)//プレーヤーのカード数値がディーラーより下ならプレーヤーの負け(如果玩家的牌点数低于庄家的牌点数，玩家即告输局)
        {
            Debug.Log("ディーラーの勝ち");
        }
        else
        {
            Debug.Log("引き分け");//どっちのカード数値も同じなら引き分け(如果两张牌的点数相同，则为平局)
        }
    }
}
