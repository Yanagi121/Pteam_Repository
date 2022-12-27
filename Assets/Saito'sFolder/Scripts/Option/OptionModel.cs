using UniRx;
using UnityEngine;

namespace Option.Saito
{
    public class OptionModel 
    {
        private readonly BoolReactiveProperty _isPushProp;
        
        /// <summary>
        /// ボタンが押されたか
        /// </summary>
        public IReactiveProperty<bool> IsPushProp => _isPushProp;
        public bool IsPush => _isPushProp.Value;
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public OptionModel()
        {
            Debug.Log("コンストラクタ発動");
            _isPushProp = new BoolReactiveProperty(false);
        }

        /// <summary>
        /// フラグを更新
        /// </summary>
        public void UpdateBool(bool isPush)
        {
            _isPushProp.Value = isPush;
        }
    }
}