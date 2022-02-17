//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Photon.Pun;

//private void PlayerProperties ()
//{
//    //自分のクライアントの同期オブジェクトにのみ
//    if (photonView.IsMine)
//    {
//        List<int> playerSetableCountList = new List<int>();

//        //制限人数までの数字のリストを作成
//        //例) 制限人数 = 4 の場合、{0,1,2,3}
//        int count = 0;
//        for (int i = 0; i < 4; i++)
//        //{
//            playerSetableCountList.Add(count);
//            count++;
//        }

//        //他の全プレイヤー取得
//        Player[] otherPlayers = PhotonNetwork.PlayerListOthers;

//        //他のプレイヤーがいなければカスタムプロパティの値を"0"に設定
//        if (otherPlayers.Length <= 0)
//        {
//            //ローカルのプレイヤーのカスタムプロパティを設定
//            int playerAssignNum = otherPlayers.Length;
//            PhotonNetwork.LocalPlayer.UpdatePlayerNum(playerAssignNum);
//            return;
//        }

//        //他のプレイヤーのカスタムプロパティー取得してリスト作成
//        List<int> playerAssignNums = new List<int>();
//        for (int i = 0; i < otherPlayers.Length; i++)
//        {
//            playerAssignNums.Add(otherPlayers[i].GetPlayerNum());
//        }

//        //リスト同士を比較し、未使用の数字のリストを作成
//        //例) 0,1にプレーヤーが存在する場合、返すリストは2,3
//        playerSetableCountList.RemoveAll(playerAssignNums.Contains);

//        //ローカルのプレイヤーのカスタムプロパティを設定
//        //空いている場所のうち、一番若い数字の箇所を利用
//        PhotonNetwork.LocalPlayer.UpdatePlayerNum(playerSetableCountList[0]);
//    }
//}
