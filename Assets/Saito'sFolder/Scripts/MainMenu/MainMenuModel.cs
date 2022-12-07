using UniRx;
using UnityEngine;

namespace Saito.MainMenu
{
    public class MainMenuModel
    {
        private BoolReactiveProperty _isPushProp;
        public IReactiveProperty<bool> IsPushProp => _isPushProp;
        public bool IsPush => _isPushProp.Value;
        
        public MainMenuModel()
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