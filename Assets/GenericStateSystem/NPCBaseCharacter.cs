using UnityEngine;

namespace GenericStateSystem
{
    public class NPCBaseCharacter : BaseCharacter
    {
        public LayerMask whatToChase;
        [HideInInspector] public Transform currentTarget;
        private Quaternion _lookRotation;
        public float _rotationSpeed = 5f;
        public float chaseSpeed = 0.8f;
        public float patrolSpeed = 0.6f;
        public void FaceCurrentTarget(float skewedBy)
        {
            if (currentTarget != null)
            {
                Vector3 _direction = (currentTarget.position - transform.position).normalized;

                //create the rotation we need to be in to look at the target
                //_character.transform.rotation = Quaternion.LookRotation(_direction);
                _lookRotation = Quaternion.LookRotation(_direction);
                var eulerY = _lookRotation.eulerAngles.y + 45f;  // animation is skewed!
                var euler = new Vector3(0, eulerY, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(euler),
                    Time.deltaTime * _rotationSpeed);
                //Debug.Log($"FaceOpponent {transform.rotation.y}");
            }
         
        }
    }
}