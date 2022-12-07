using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace InGame.Saito
{
    public class InGamePresenter : MonoBehaviour
    {
        [SerializeField] private InGameModel _model;
        [SerializeField] private InGameView _view;

        // Start is called before the first frame update
       private void Start()
        {
            try
            {
              Initialized();
              Bind();
              SetEvent();
            }
            catch (NullReferenceException ex)
            {
                //警告メッセージを表示する
                Debug.LogWarning($"<color=red>オブジェクトがnullである可能性があります。{this.name}の取得メソッド、publicを確認してください。:{ex}</color>");
            }
            //メソッドの引数がnullだったら
            catch (ArgumentNullException ex)
            {
                //警告メッセージを表示する
                Debug.LogWarning($"<color=red>メソッドの引数がnullです。{this.name}にあるメソッドの引数を確認してください。：{ex}</color>");
            }
            //メソッドの引数が不正だったら
            catch (ArgumentException ex)
            {
                //警告メッセージを表示する
                Debug.LogWarning($"<color=red>メソッドの引数が不正です。{this.name}にあるメソッドの引数を確認してください。：{ex}</color>");
            }
            //今迄の例外にヒットしなかった場合
            catch (Exception ex)
            {
                throw ex;
            }
        }

       private void Initialized()
       {
           _view.Initialized();
           _model.Initialized();
       }

       private void Bind()
       {
       }

       private void SetEvent()
       {
       }
    }  
}

