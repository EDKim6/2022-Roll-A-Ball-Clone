using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float       minHeight;
    private Movement3D  movement3D;

    private void Awake()
    {
        movement3D = GetComponent<Movement3D>();
    }

    private void Update()
    {
        // 방향키를 눌러 이동
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if ( x != 0 || z != 0 )
        {
            // (x, 0, z) 방향으로 이동
            movement3D.MoveTo(new Vector3(x, 0, z));
        }

        // 낭떠러지로 플레이어가 떨어지는지 체크
        ChangeSceneFallDown();
    }

    private void ChangeSceneFallDown()
    {
        if ( transform.position.y < minHeight )
        {
            // 현재 씬을 로드 (현재 씬 재시작)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
