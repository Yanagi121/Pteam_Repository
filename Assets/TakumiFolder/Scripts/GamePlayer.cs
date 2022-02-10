using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;


// IPunObservableインターフェースを実装する
[RequireComponent(typeof(SpriteRenderer))]
public class GamePlayer : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshPro nameLabel = default;

    private ProjectileManager projectileManager;
    private SpriteRenderer spriteRenderer;
    // 弾を発射する時に使う弾のID
    private int projectileId = 0;
    public Player Owner => photonView.Owner;
    private void Awake()
    {
        var gamePlayerManager = GameObject.FindWithTag("GamePlayerManager").GetComponent<GamePlayerManager>();
        transform.SetParent(gamePlayerManager.transform);

        projectileManager = GameObject.FindWithTag("ProjectileManager").GetComponent<ProjectileManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        //プレイヤー名の横にスコアを表示する
        int score = photonView.Owner.GetScore();
        nameLabel.text = $"{photonView.Owner.NickName}({score.ToString()})";

        //色相値が設定されていたら、スプライトの色を変える
        if (photonView.Owner.TryGetHue(out float hue))
        {
            spriteRenderer.color = Color.HSVToRGB(hue, 1f, 1f);
        }
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            var dv = 6f * Time.deltaTime * direction;
            transform.Translate(dv.x, dv.y, 0f);

            // 左クリックでカーソルの方向に弾を発射する処理を行う
            if (Input.GetMouseButtonDown(0))
            {
                var playerWorldPosition = transform.position;
                var mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var dp = mouseWorldPosition - playerWorldPosition;
                float angle = Mathf.Atan2(dp.y, dp.x);

                // FireProjectile(angle);をRPCで実行する
                photonView.RPC(nameof(FireProjectile), RpcTarget.All, transform.position, angle);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (photonView.IsMine)
        {
            var projectile = collision.GetComponent<projectile>();
            if (projectile != null && projectile.OwnerId != PhotonNetwork.LocalPlayer.ActorNumber)
            {
                photonView.RPC(nameof(HitByProjectile), RpcTarget.All, projectile.Id, projectile.OwnerId);
            }
        }
    }
    [PunRPC]
    private void HitByProjectile(int projectileId, int ownerId)
    {
        projectileManager.Remove(projectileId, ownerId);
        if (photonView.IsMine)
        {
            //弾に当たったのが自身のオブジェクトなら、自身の色相値を更新する
            PhotonNetwork.LocalPlayer.OnTakeDamage();
        }
        else if (ownerId == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            //（他プレイヤーのオブジェクトが）自身の弾に当たったなら、自身のスコアを更新する
            PhotonNetwork.LocalPlayer.OnDealDamage();
        }
    }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (targetPlayer.ActorNumber != photonView.OwnerActorNr) { return; }

        //スコアが更新されていたら、スコア表示を更新する
        if (changedProps.TryGetScore(out int score)){
                nameLabel.text = $"{photonView.Owner.NickName}({score.ToString()})";
            }
        //色相値が更新されていたら、スプライトの色を変化させる
        if(changedProps.TryGetHue(out float hue))
        {
            spriteRenderer.color = Color.HSVToRGB(hue, 1f, 1f);      
        }
    }

    //[PunRPC]属性をつけるとRPCでの実行が有効になる
    // 弾を発射するメソッド
    [PunRPC]
    private void FireProjectile(Vector3 origin, float angle, PhotonMessageInfo info)
    {
        int timestamp = info.SentServerTimestamp;
        projectileManager.Fire(timestamp, photonView.OwnerActorNr, origin, angle, timestamp);
    }

}