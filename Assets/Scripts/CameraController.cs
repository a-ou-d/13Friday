using UnityEngine;

public class CameraController : MonoBehaviour
{
    public string playerTag = "Player"; // 플레이어를 나타내는 태그

    private Transform thisTransform;
    private Transform targetTransform;

    void Start()
    {
        thisTransform = transform;

        // playerTag로 지정된 오브젝트를 찾아서 Target으로 설정
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObject != null)
        {
            targetTransform = playerObject.transform;
        }
        else
        {
            Debug.Log("태그되어 있는 오브젝트를 찾을 수 없읍니다.");
        }
    }

    void FixedUpdate()
    {
        if (targetTransform != null)
        {
            Vector3 targetPosition = new Vector3(targetTransform.position.x, targetTransform.position.y, thisTransform.position.z);
            thisTransform.position = targetPosition;
        }
    }
}
