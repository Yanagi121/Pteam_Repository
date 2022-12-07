using UniRx;
using UnityEngine;

namespace Help.Saito
{
    public class HelpModel 
    {
        private BoolReactiveProperty _isPushProp;
        public IReactiveProperty<bool> IsPushProp => _isPushProp;
        public bool IsPush => _isPushProp.Value;
        
        public HelpModel()
        {
            Debug.Log("コンストラクタ発動");
            _isPushProp = new BoolReactiveProperty(false);
        }

        public void UpdateBool(bool isPush)
        {
            _isPushProp.Value = isPush;
        }
    }
}