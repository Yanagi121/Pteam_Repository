using UniRx;
using UnityEngine;

namespace Lobby.Saito
{
    public class LobbyModel
    {
        private BoolReactiveProperty _isPushProp;
        public IReactiveProperty<bool> IsPushProp => _isPushProp;
        public bool IsPush => _isPushProp.Value;
        
        public LobbyModel()
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