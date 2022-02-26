using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public AudioSource AS;
    private MoleFSM molefsm;
    public GameManager manager;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "mole"){
            molefsm = other.GetComponent<MoleFSM>();
            manager.currentscore++;
            AS.Play();
            molefsm.ChangeState(MoleState.UnderGround);
        }
    }
}
