using UniRx;
using UnityEngine;

namespace Lobby.Saito
{
    public class LobbyModel
    {
        private BoolReactiveProperty _isPushProp;
        /// <summary>
        /// ボタンが押されたか
        /// </summary>
        public IReactiveProperty<bool> IsPushProp => _isPushProp;
        public bool IsPush => _isPushProp.Value;
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public LobbyModel()
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