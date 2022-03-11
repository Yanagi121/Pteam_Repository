using System.Collections.Generic;
using UnityEngine;

public class GamePlayerManager : MonoBehaviour
{
    private List<GamePlayer> playerList = new List<GamePlayer>();

    public GamePlayer this[int index]=>playerList[index];
    public int Count=>playerList.Count;

    private void OnTransformChildrenChanged()
    {
        //�q�v�f���ς������A�l�b�g���[�N�I�u�W�F�N�g�̃��X�g���X�V����
        playerList.Clear();
        foreach(Transform child in transform)
        {
            playerList.Add(child.GetComponent<GamePlayer>());
        }
    }
}
