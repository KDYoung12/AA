using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f; // 10의 속도로 위쪽 방향으로 이동

    private bool isPinned = false; // 붙었나?

    private bool isLaunched = false; // 눌렀나?
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isPinned && isLaunched)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPinned = true;
        if (collision.gameObject.tag == "Target")
        {
            // 자식 오브젝트를 찾는
            // 첫 번째 방법
             GameObject childObject = transform.Find("Square").gameObject;

            // 두 번째 방법
            //GameObject childObject = transform.GetChild(0).gameObject; // 첫 번째 자식 오브젝트 받아오기
            SpriteRenderer childeSprite = childObject.GetComponent<SpriteRenderer>();
            childeSprite.enabled = true; // 활성화

            transform.SetParent(collision.gameObject.transform);

            GameManager.instance.DecreaseGoal();
        }

        else if(collision.gameObject.tag == "Pin")
        {
            GameManager.instance.SetGameOver(false);
        }
    }

    public void Launch()
    {
        isLaunched = true;
    }
}
