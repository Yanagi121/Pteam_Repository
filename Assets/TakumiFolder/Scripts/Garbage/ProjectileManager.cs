using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private projectile projectilePrefab = default;//Projectile��Prefab�Q��

    //�A�N�e�B�u�Ȓe�̃��X�g
    private List<projectile> activeList = new List<projectile>();
    //��A�N�e�B�u�Ȓe�̃I�u�W�F�N�g�v�[��
    private Stack<projectile> inactivePool = new Stack<projectile>();
    void Update()
    {
        //�t���Ƀ��[�v���񂵂āAactiveList�̗v�f���r���ō폜����Ă����������[�v�����悤�ɂ���
        for(int i = activeList.Count - 1; i >= 0; i--)
        {
            var projectile = activeList[i];
            if (projectile.IsActive)
            {
                projectile.OnUpdate();
            }
            else
            {
                Remove(projectile);
            }
        }
    }

    //�e�̔��ˁi�A�N�e�B�u���j
    public void Fire(int id, int ownerId, Vector3 origin,float angle,int timestamp)
    {
        //��A�N�e�B�u�̒e������Ύg���܂킷�A������ΐ�������
        var projectile = (inactivePool.Count > 0) ? inactivePool.Pop() : Instantiate(projectilePrefab, transform);
        projectile.Activate(id, ownerId, origin, angle, timestamp);
        activeList.Add(projectile);
    }

    public void Remove(projectile projectile)
    {
        activeList.Remove(projectile);
        projectile.Deactivate();
        inactivePool.Push(projectile);
    }
    public void Remove(int id, int ownerId)
    {
        foreach (var projectile in activeList)
        {
            if (projectile.Equals(id, ownerId))
            {
                Remove(projectile);
                break;
            }
        }
    }
}
