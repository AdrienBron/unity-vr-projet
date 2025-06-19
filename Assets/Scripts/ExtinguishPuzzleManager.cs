using UnityEngine;
using System.Linq;

public class ExtinguishPuzzleManager : MonoBehaviour
{
    public CandleExtinguish[] candles;  // assignez vos 4 bougies
    public Animator          doorAnimator;

    bool opened = false;

    void Update()
    {
        if (opened) return;
        if (candles.All(c => !c.IsLit))
        {
            opened = true;
            doorAnimator.SetBool("Open", true);
        }
    }
}
