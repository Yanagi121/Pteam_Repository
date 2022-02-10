using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;


// IPunObservable�C���^�[�t�F�[�X����������
[RequireComponent(typeof(SpriteRenderer))]
public class GamePlayer : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshPro nameLabel = default;

    private ProjectileManager projectileManager;
    private SpriteRenderer spriteRenderer;
    // �e�𔭎˂��鎞�Ɏg���e��ID
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
        //�v���C���[���̉��ɃX�R�A��\������
        int score = photonView.Owner.GetScore();
        nameLabel.text = $"{photonView.Owner.NickName}({score.ToString()})";

        //�F���l���ݒ肳��Ă�����A�X�v���C�g�̐F��ς���
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

            // ���N���b�N�ŃJ�[�\���̕����ɒe�𔭎˂��鏈�����s��
            if (Input.GetMouseButtonDown(0))
            {
                var playerWorldPosition = transform.position;
                var mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var dp = mouseWorldPosition - playerWorldPosition;
                float angle = Mathf.Atan2(dp.y, dp.x);

                // FireProjectile(angle);��RPC�Ŏ��s����
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
            //�e�ɓ��������̂����g�̃I�u�W�F�N�g�Ȃ�A���g�̐F���l���X�V����
            PhotonNetwork.LocalPlayer.OnTakeDamage();
        }
        else if (ownerId == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            //�i���v���C���[�̃I�u�W�F�N�g���j���g�̒e�ɓ��������Ȃ�A���g�̃X�R�A���X�V����
            PhotonNetwork.LocalPlayer.OnDealDamage();
        }
    }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (targetPlayer.ActorNumber != photonView.OwnerActorNr) { return; }

        //�X�R�A���X�V����Ă�����A�X�R�A�\�����X�V����
        if (changedProps.TryGetScore(out int score)){
                nameLabel.text = $"{photonView.Owner.NickName}({score.ToString()})";
            }
        //�F���l���X�V����Ă�����A�X�v���C�g�̐F��ω�������
        if(changedProps.TryGetHue(out float hue))
        {
            spriteRenderer.color = Color.HSVToRGB(hue, 1f, 1f);      
        }
    }

    //[PunRPC]�����������RPC�ł̎��s���L���ɂȂ�
    // �e�𔭎˂��郁�\�b�h
    [PunRPC]
    private void FireProjectile(Vector3 origin, float angle, PhotonMessageInfo info)
    {
        int timestamp = info.SentServerTimestamp;
        projectileManager.Fire(timestamp, photonView.OwnerActorNr, origin, angle, timestamp);
    }

}