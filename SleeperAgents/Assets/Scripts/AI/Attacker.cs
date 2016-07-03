using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {
    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private bool weaponDrawn = false;
    private Weapon weapon;

    // Use this for initialization
    void Start()
    {
        weapon = inventory.equipedWeapon;
        weapon.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (Input.GetMouseButtonDown(1) && weaponDrawn)
        {
            weapon.gameObject.SetActive(true);
        } else
        {
			weapon.gameObject.SetActive (false);
        }
    }

    public void ToggleDrawnWeapon()
    {
        weaponDrawn = !weaponDrawn;
    }
}
