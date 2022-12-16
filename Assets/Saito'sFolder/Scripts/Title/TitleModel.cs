using UniRx;
using UnityEngine;

namespace Title.Saito
{
    public class TitleModel
    {
        private readonly ReactiveProperty<bool> _isFadeProp;
        
        /// <summary>
        /// ボタンが押されたか
        /// </summary>
        public IReadOnlyReactiveProperty<bool> IsFadeProp => _isFadeProp;
        public bool IsFade => _isFadeProp.Value;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TitleModel()
        {
            _isFadeProp = new ReactiveProperty<bool>(false);
        }

        /// <summary>
        /// フラグを更新
        /// </summary>
        public void BoolUpdate(bool isFade)
        {
            _isFadeProp.Value = isFade;
            Debug.Log("値が書き変わりました");
        }
    }  
}

