using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f; // 10�� �ӵ��� ���� �������� �̵�

    private bool isPinned = false; // �پ���?

    private bool isLaunched = false; // ������?
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
            // �ڽ� ������Ʈ�� ã��
            // ù ��° ���
             GameObject childObject = transform.Find("Square").gameObject;

            // �� ��° ���
            //GameObject childObject = transform.GetChild(0).gameObject; // ù ��° �ڽ� ������Ʈ �޾ƿ���
            SpriteRenderer childeSprite = childObject.GetComponent<SpriteRenderer>();
            childeSprite.enabled = true; // Ȱ��ȭ

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
