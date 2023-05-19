using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject player; // Referencia al objeto del jugador con la etiqueta "Player"
    public GameObject bulletPrefab; // Prefab de la bala
    public float fireRate = 1f; // Velocidad de disparo (tiempo entre disparos)
    public float detectionRange = 10f; // Rango de detección del jugador
    public float dispersionRange = 1f; // Rango de dispersión de las balas
    public float bulletSpeed = 10f; // Velocidad de la bala

    private float nextFireTime; // Tiempo para el próximo disparo

    private void Update()
    {
        // Verificar si es tiempo de disparar
        if (Time.time >= nextFireTime)
        {
            // Verificar si el jugador está dentro del rango de visión
            if (Vector3.Distance(transform.position, player.transform.position) < detectionRange)
            {
                // Calcular la posición objetivo dentro de un rango aleatorio
                Vector3 targetPosition = player.transform.position + Random.insideUnitSphere * dispersionRange;

                // Disparar hacia la posición objetivo
                Shoot(targetPosition);

                // Actualizar el tiempo para el próximo disparo
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    private void Shoot(Vector3 targetPosition)
    {
        // Instanciar la bala
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Calcular la dirección hacia la posición objetivo
        Vector3 shootDirection = (targetPosition - transform.position).normalized;

        // Aplicar fuerza a la bala en la dirección calculada
        bullet.GetComponent<Rigidbody>().AddForce(shootDirection * bulletSpeed, ForceMode.Impulse);
    }
}
