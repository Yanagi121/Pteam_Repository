using UniRx;
using UnityEngine;

namespace Title.Saito
{
    public class TitleModel
    {
        private readonly ReactiveProperty<bool> _isFadeProp;
        public IReadOnlyReactiveProperty<bool> IsFadeProp => _isFadeProp;
        public bool IsFade => _isFadeProp.Value;

        /// <summary>
        /// 初期化処理
        /// </summary>
        public TitleModel()
        {
            _isFadeProp = new ReactiveProperty<bool>(false);
        }

        /// <summary>
        /// Flagの値を変える(bool)
        /// </summary>
        /// <param name="isFade"></param>
        public void BoolUpdate(bool isFade)
        {
            _isFadeProp.Value = isFade;
            Debug.Log("値が書き変わりました");
        }
    }  
}

