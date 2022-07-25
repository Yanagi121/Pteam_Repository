using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private projectile projectilePrefab = default;//ProjectileのPrefab参照

    //アクティブな弾のリスト
    private List<projectile> activeList = new List<projectile>();
    //非アクティブな弾のオブジェクトプール
    private Stack<projectile> inactivePool = new Stack<projectile>();
    void Update()
    {
        //逆順にループを回して、activeListの要素が途中で削除されても正しくループが回るようにする
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

    //弾の発射（アクティブ化）
    public void Fire(int id, int ownerId, Vector3 origin,float angle,int timestamp)
    {
        //非アクティブの弾があれば使いまわす、無ければ生成する
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
