using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Option.Saito
{
    /// <summary>
    /// 
    /// </summary>
    public class OptionManager : MonoBehaviour
    {
        //TODO:Modelと連携して実装すべき
        //TODO:OptionSwitchingViewにクラス名を変更するべき
        
        //Button
        [SerializeField] private Button _soundButton;
        [SerializeField] private Button _creditButton;

        //Panel
        [SerializeField] private GameObject _soundpanel;
        [SerializeField] private GameObject _creditpanel;

        //Image
        [SerializeField] private Sprite _soundAciveImage;
        [SerializeField] private Sprite _soundNotAciveImage;
        [SerializeField] private Sprite _creditAciveImage;
        [SerializeField] private Sprite _creditNotAciveImage;

        // Start is called before the first frame update
        public void Initialize()
        {
            //サウンドボタンを押されたら
            _soundButton.OnClickAsObservable()
                .Select(_ => _creditpanel.gameObject.activeSelf)
                .Subscribe(value =>
                {
                    if (value)
                    {
                        _creditButton.image.sprite = _creditNotAciveImage;
                        _creditpanel.gameObject.SetActive(false);
                    }
                    _soundButton.image.sprite = _soundAciveImage;
                    _soundpanel.gameObject.SetActive(true);
                }).AddTo(this);

            //クレジットボタンが押されたら
            _creditButton.OnClickAsObservable()
                .Select(_ => _soundpanel.gameObject.activeSelf)
                .Subscribe(value =>
                {
                    if (value)
                    {
                        _soundButton.image.sprite = _soundNotAciveImage;
                        _soundpanel.gameObject.SetActive(false);
                    }

                    _creditButton.image.sprite = _creditAciveImage;
                    _creditpanel.gameObject.SetActive(true);
                }).AddTo(this);
        }
    }
}