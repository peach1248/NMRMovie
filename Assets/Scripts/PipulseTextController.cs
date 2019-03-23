using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipulseTextController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowAnimation()
    {
        var moveHash = new Hashtable();

        moveHash.Add("position", new Vector3(2f, 2f, 0));
        moveHash.Add("time", 2f);
        moveHash.Add("delay", 1f);
        moveHash.Add("easeType", "easeInOutBack");
        moveHash.Add("oncomplete", "AnimationEnd");
        moveHash.Add("oncompletetarget", this.gameObject);
        moveHash.Add("ignoretimescale", true);
        iTween.MoveTo(this.gameObject, moveHash);
    }

    void AnimationEnd()
    {
        var time = 2f;

        // パターン２ [HashをiTweenの中で宣言いていく方法]
        // 移動
        iTween.MoveTo(this.gameObject, iTween.Hash(
            "x", -3f,
            "time", time,
            "oncomplete", "AnimationEnd",
            "oncompletetarget", this.gameObject,
            "easeType", "easeInOutBack"
        ));

        // 回転
        iTween.RotateTo(this.gameObject, iTween.Hash(
            "x", 90,
            "time", time
        ));

        // 大きさ
        iTween.ScaleTo(this.gameObject, iTween.Hash(
            "x", 2f,
            "y", 2f,
            "z", 2f,
            "time", time
        ));
    }

}
