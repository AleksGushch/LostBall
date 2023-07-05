using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Labirint
{
    public class WinTrigger : MonoBehaviour
    {
        private bool checkWinZone = false;
        public bool CheckWinZone
        {
            get { return checkWinZone; }
            set { checkWinZone = value; }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                checkWinZone = true;
            }
        }
    }
}
