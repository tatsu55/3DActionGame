using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints; // ����n�_
    public Transform player; // �v���C���[��Transform
    public float detectionRange = 10f; // �v���C���[�����m���鋗��
    public float waitTime = 5f; // �ҋ@����

    private NavMeshAgent agent;
    private Animator animator;
    private int currentWaypointIndex = 0;
    private bool isWaiting = false;
    private bool isChasingPlayer = false; // �v���C���[�ǐՒ��t���O
    private Collider weaponCollider; // ����̃R���C�_�[

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        weaponCollider = GetComponentInChildren<Collider>(); // ����̃R���C�_�[���擾

        MoveToNextWaypoint();
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);

        // �v���C���[�����m���ĒǐՂ��J�n
        if (dist <= detectionRange)
        {
            StartChasingPlayer();
        }
        // �v���C���[�����m���Ă��Ȃ��ꍇ�͏���
        else if (isChasingPlayer)
        {
            StopChasingPlayer();
        }

        // �ǐՒ��̓v���C���[��ǂ�������
        if (isChasingPlayer)
        {
            ChasePlayer(dist);
        }
        // ����ȊO�͏���
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
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // ���̒n�_��ݒ�
    }

    System.Collections.IEnumerator WaitAtWaypoint()
    {
        isWaiting = true; // �ҋ@��Ԃɂ���
        agent.isStopped = true; // �ړ����~

        yield return new WaitForSeconds(waitTime); // �w�肵���b���ҋ@

        agent.isStopped = false; // �Ăшړ����J�n
        isWaiting = false; // �ҋ@��Ԃ�����
        MoveToNextWaypoint(); // ���̒n�_�ֈړ�
    }

    void StartChasingPlayer()
    {
        isChasingPlayer = true;
    }

    void StopChasingPlayer()
    {
        isChasingPlayer = false;
        agent.isStopped = false; // NavMeshAgent�̐�����ĊJ
        MoveToNextWaypoint(); // ������ĊJ
    }

    void ChasePlayer(float dist)
    {
        // �v���C���[������NavMeshAgent�ňړ�
        agent.SetDestination(player.position);

        // �v���C���[�Ƃ̋�����2.0f�����̏ꍇ�͍U�����[�h
        if (dist < 2.0f)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isAttacking", true);
            WeaponOn(); // �U���͈͓��ŕ���R���C�_�[��L���ɂ���
        }
        else
        {
            animator.SetBool("isRunning", true);
            animator.SetBool("isAttacking", false);
            WeaponOff(); // �U���͈͊O�ŕ���R���C�_�[�𖳌��ɂ���
        }
    }

    // �U�����ɕ���R���C�_�[��L���ɂ���
    void WeaponOn()
    {
            weaponCollider.enabled = true;
    }

    // �U�����ɕ���R���C�_�[�𖳌��ɂ���
    void WeaponOff()
    {
            weaponCollider.enabled = false;
    }
}
