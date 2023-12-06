using UnityEngine;

public class CameraController : MonoBehaviour
{
    public string playerTag = "Player"; // �÷��̾ ��Ÿ���� �±�

    private Transform thisTransform;
    private Transform targetTransform;

    void Start()
    {
        thisTransform = transform;

        // playerTag�� ������ ������Ʈ�� ã�Ƽ� Target���� ����
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObject != null)
        {
            targetTransform = playerObject.transform;
        }
        else
        {
            Debug.Log("�±׵Ǿ� �ִ� ������Ʈ�� ã�� �� �����ϴ�.");
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
