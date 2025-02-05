using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints; // 巡回地点
    public Transform player; // プレイヤーのTransform
    public float detectionRange = 10f; // プレイヤーを検知する距離
    public float waitTime = 5f; // 待機時間

    private NavMeshAgent agent;
    private Animator animator;
    private int currentWaypointIndex = 0;
    private bool isWaiting = false;
    private bool isChasingPlayer = false; // プレイヤー追跡中フラグ
    private Collider weaponCollider; // 武器のコライダー

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        weaponCollider = GetComponentInChildren<Collider>(); // 武器のコライダーを取得

        MoveToNextWaypoint();
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);

        // プレイヤーを検知して追跡を開始
        if (dist <= detectionRange)
        {
            StartChasingPlayer();
        }
        // プレイヤーを検知していない場合は巡回
        else if (isChasingPlayer)
        {
            StopChasingPlayer();
        }

        // 追跡中はプレイヤーを追いかける
        if (isChasingPlayer)
        {
            ChasePlayer(dist);
        }
        // それ以外は巡回
        else
        {
            Patrol();
            animator.SetBool("isRunning", agent.velocity.magnitude > 0.1f);
        }     

    }

    void Patrol()
    {
        if (!isWaiting && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            StartCoroutine(WaitAtWaypoint());
        }
    }

    void MoveToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        agent.SetDestination(waypoints[currentWaypointIndex].position);
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // 次の地点を設定
    }

    System.Collections.IEnumerator WaitAtWaypoint()
    {
        isWaiting = true; // 待機状態にする
        agent.isStopped = true; // 移動を停止

        yield return new WaitForSeconds(waitTime); // 指定した秒数待機

        agent.isStopped = false; // 再び移動を開始
        isWaiting = false; // 待機状態を解除
        MoveToNextWaypoint(); // 次の地点へ移動
    }

    void StartChasingPlayer()
    {
        isChasingPlayer = true;
    }

    void StopChasingPlayer()
    {
        isChasingPlayer = false;
        agent.isStopped = false; // NavMeshAgentの制御を再開
        MoveToNextWaypoint(); // 巡回を再開
    }

    void ChasePlayer(float dist)
    {
        // プレイヤー方向にNavMeshAgentで移動
        agent.SetDestination(player.position);

        // プレイヤーとの距離が2.0f未満の場合は攻撃モード
        if (dist < 2.0f)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isAttacking", true);
            WeaponOn(); // 攻撃範囲内で武器コライダーを有効にする
        }
        else
        {
            animator.SetBool("isRunning", true);
            animator.SetBool("isAttacking", false);
            WeaponOff(); // 攻撃範囲外で武器コライダーを無効にする
        }
    }

    // 攻撃時に武器コライダーを有効にする
    void WeaponOn()
    {
            weaponCollider.enabled = true;
    }

    // 攻撃時に武器コライダーを無効にする
    void WeaponOff()
    {
            weaponCollider.enabled = false;
    }
}
