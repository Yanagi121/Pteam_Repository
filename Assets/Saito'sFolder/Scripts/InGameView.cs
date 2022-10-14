using DG.Tweening;
using TMPro;
using UnityEngine;

public class InGameView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    
    void Start()
    {
        _text.DOCounter(0, 100,10)
            .SetEase(Ease.Linear).SetLink(this.gameObject);
    }
}
