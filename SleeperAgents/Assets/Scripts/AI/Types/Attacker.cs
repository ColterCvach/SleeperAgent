using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {
    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private bool _weaponDrawn = false;
    public bool weaponDrawn { get { return _weaponDrawn; } }
    private Weapon _weapon;
    public Weapon weapon { get { return _weapon; } }

    // Use this for initialization
    void Start()
    {
        _weapon = inventory.equipedWeapon;
        weapon.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (_weaponDrawn)
        {
            weapon.gameObject.SetActive(true);
        } else
        {
			weapon.gameObject.SetActive (false);
        }
    }

    public void ToggleDrawnWeapon()
    {
        _weaponDrawn = !_weaponDrawn;
    }
}
