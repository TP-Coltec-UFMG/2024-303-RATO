using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    [SerializeField] private GameObject InteragirTutorial;
    [SerializeField] private Transform TeleportThis;
    [SerializeField] private Vector3 NewPosition;

    [Header("Controle de Cooldown")]
    [Tooltip("Tempo em segundos para prevenir ativações duplas após o teleport.")]
    public float cooldownTempo = 0.2f; 
    private static float proximaAcaoTempo = 0f;

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.CompareTag("Player"))
        {
            if (Time.time >= proximaAcaoTempo)
            {
                InteragirTutorial.SetActive(true);
                StartCoroutine(WaitForKeyPress());
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        if (GetComponent<Collider>().gameObject.CompareTag("Player"))
        {
            InteragirTutorial.SetActive(false);
            StopAllCoroutines();
        }
    }

    private IEnumerator WaitForKeyPress(){
        while (!UserInput.Instance.InteractInput) {
            yield return null;
        }

        if (Time.time >= proximaAcaoTempo)
        {
            Teleport();
            proximaAcaoTempo = Time.time + cooldownTempo; 
        }
    }

    private void Teleport(){
        TeleportThis.position = NewPosition;
    }
}
