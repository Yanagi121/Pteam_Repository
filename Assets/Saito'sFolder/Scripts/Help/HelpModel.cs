using UniRx;
using UnityEngine;

namespace Help.Saito
{
    public class HelpModel
    {
        private readonly BoolReactiveProperty _isPushProp;
        private readonly FloatReactiveProperty _pageCurrentNumProp;
        
        /// <summary>
        /// ボタンが押されたか
        /// </summary>
        public IReactiveProperty<bool> IsPushProp => _isPushProp;

        /// <summary>
        /// 
        /// </summary>
        public IReactiveProperty<float> PageCurrentNumProp => _pageCurrentNumProp;

        public bool IsPush => _isPushProp.Value;
        public float PageCurrentNum=>_pageCurrentNumProp.Value;
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HelpModel()
        {
            _isPushProp = new BoolReactiveProperty(false);
            _pageCurrentNumProp = new FloatReactiveProperty(0.0f);
        }

        /// <summary>
        /// フラグを更新
        /// </summary>
        public void UpdateBool(bool isPush)
        {
            _isPushProp.Value = isPush;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void UpdatePageNum(float pageNextNum)
        {
            _pageCurrentNumProp.Value = Mathf.Clamp(pageNextNum,0.0f,2.0f);
        }
    }
}