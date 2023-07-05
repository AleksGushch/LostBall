using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Labirint
{


    public class LooseTrigger : MonoBehaviour
    {
        private bool checkLooseZone = false;
        public bool CheckLooseZone
        {
            get { return checkLooseZone; }
            set { checkLooseZone = value; }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                checkLooseZone = true;
            }
        }
    }
}