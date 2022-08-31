using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Saito.Title.Views
{
    public class ButtonView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        private Tween _tween;
        
        /// <summary>
        /// PlayGameTextを拡大する
        /// </summary>
        public void Enlargeimge()
        {
            _image.transform.DOScale(Vector3.one, 1.0f);
        }
    }
}