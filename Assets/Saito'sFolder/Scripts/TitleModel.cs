using UniRx;
using UnityEngine;

namespace Title.Saito
{
    public class TitleModel : MonoBehaviour
    {
        public bool Flag => _flag;
        private bool _flag;

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Initialized()
        {
            _flag = false;
        }

        /// <summary>
        /// Flagの値を変える(bool)
        /// </summary>
        /// <param name="flag"></param>
        public void ValueUpdate(bool flag)
        {
            _flag = flag;
            Debug.Log("値が書き変わりました");
        }
    }  
}

