using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    public int curHp;
    public int maxHp;

    [Header("Movement")]
    public float moveSpeed;
    public float jumpForce;

    [Header("Camera")]
    public float lookSensibility;
    public float maxLookX;
    public float minLookX;
    private float rotX;

    private Camera cam;
    private Rigidbody rb;
    public Weapon weapon;

    private void Awake()
    {
        // get components
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        weapon = GetComponent<Weapon>();

        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        // initializa the UI
        GameUI.instance.UpdateHealthBar(curHp, maxHp);
        GameUI.instance.UpdateScoreText(0);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);

    }

    private void Update()
    {
        // dont do anything if game is paused
        if (GameManager.instance.gamePaused == true)
            return;

        Move();

        if(Input.GetButtonDown("Jump"))
            TryJump();

        if(Input.GetButtonDown("Fire1"))
        {
            if (weapon.CanShoot())
                weapon.Shoot();
        }

        CamLook();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal")* moveSpeed;
        float z = Input.GetAxis("Vertical")* moveSpeed;

        Vector3 dir = transform.right * x + transform.forward * z;
        dir.y = rb.velocity.y;

        rb.velocity = dir;
    }

    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensibility;
        rotX += Input.GetAxis("Mouse Y") * lookSensibility;

        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);

        cam.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;

    }

    void TryJump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, 1.1f))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse );
    }

    public void TakeDamage(int damage)
    {
        curHp -= damage;

        GameUI.instance.UpdateHealthBar(curHp, maxHp);

        if (curHp <= 0)
            Die();
    }

    void Die()
    {
        GameManager.instance.LoseGame();
    }

    public void GiveHealth ( int amountToGive)
    {
        curHp = Mathf.Clamp(curHp + amountToGive, 0, maxHp);

        GameUI.instance.UpdateHealthBar(curHp, maxHp);
    }

    public void GiveAmmo (int amountToGive)
    {
        weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);

        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }

}
