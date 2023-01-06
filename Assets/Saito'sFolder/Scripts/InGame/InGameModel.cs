using UniRx;
using UnityEngine;

namespace InGame.Saito
{
    /// <summary>
    /// 
    /// </summary>
    public class InGameModel : MonoBehaviour
    {
        private BoolReactiveProperty _isPushProp;
        public IReactiveProperty<bool> IsPushProp => _isPushProp;
        public bool IsPush => _isPushProp.Value;

        /// <summary>
        /// 
        /// </summary>
        public void Initialized()
        {
            _isPushProp = new BoolReactiveProperty(false);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetValue(bool isPush)
        {
            _isPushProp.Value = isPush;
        }
    }
}