//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Photon.Pun;

//private void PlayerProperties ()
//{
//    //�����̃N���C�A���g�̓����I�u�W�F�N�g�ɂ̂�
//    if (photonView.IsMine)
//    {
//        List<int> playerSetableCountList = new List<int>();

//        //�����l���܂ł̐����̃��X�g���쐬
//        //��) �����l�� = 4 �̏ꍇ�A{0,1,2,3}
//        int count = 0;
//        for (int i = 0; i < 4; i++)
//        //{
//            playerSetableCountList.Add(count);
//            count++;
//        }

//        //���̑S�v���C���[�擾
//        Player[] otherPlayers = PhotonNetwork.PlayerListOthers;

//        //���̃v���C���[�����Ȃ���΃J�X�^���v���p�e�B�̒l��"0"�ɐݒ�
//        if (otherPlayers.Length <= 0)
//        {
//            //���[�J���̃v���C���[�̃J�X�^���v���p�e�B��ݒ�
//            int playerAssignNum = otherPlayers.Length;
//            PhotonNetwork.LocalPlayer.UpdatePlayerNum(playerAssignNum);
//            return;
//        }

//        //���̃v���C���[�̃J�X�^���v���p�e�B�[�擾���ă��X�g�쐬
//        List<int> playerAssignNums = new List<int>();
//        for (int i = 0; i < otherPlayers.Length; i++)
//        {
//            playerAssignNums.Add(otherPlayers[i].GetPlayerNum());
//        }

//        //���X�g���m���r���A���g�p�̐����̃��X�g���쐬
//        //��) 0,1�Ƀv���[���[�����݂���ꍇ�A�Ԃ����X�g��2,3
//        playerSetableCountList.RemoveAll(playerAssignNums.Contains);

//        //���[�J���̃v���C���[�̃J�X�^���v���p�e�B��ݒ�
//        //�󂢂Ă���ꏊ�̂����A��ԎႢ�����̉ӏ��𗘗p
//        PhotonNetwork.LocalPlayer.UpdatePlayerNum(playerSetableCountList[0]);
//    }
//}
