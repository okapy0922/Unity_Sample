using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // �p�X�����ɕK�v��navmesh�G�[�W�F���g
        public ThirdPersonCharacter character { get; private set; } // ���䂵�Ă���L�����N�^�[
        public Transform target;                                    // �ڎw���^�[�Q�b�g


        private void Start()
        {
            // �K�v�ȃI�u�W�F�N�g�̃R���|�[�l���g���擾����i�R���|�[�l���g��K�v�Ƃ��邽��null�ɂ��Ȃ��j
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }


        private void Update()
        {
            if (target != null)
                agent.SetDestination(target.position);

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}