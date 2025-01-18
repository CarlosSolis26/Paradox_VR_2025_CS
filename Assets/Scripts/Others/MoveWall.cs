using UnityEngine;

namespace Others
{
    public class MoveWall : MonoBehaviour
    {
        public Transform puntoInicio;
        public Transform puntoFinal;
        public float velocidad = 3f;

        private Vector3 posObjetivo = Vector3.zero;

        private void Start()
        {
            posObjetivo = puntoFinal.position;
        }

        private void FixedUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position, posObjetivo, velocidad * Time.fixedDeltaTime);
            if (transform.position == posObjetivo)
            {
                if (transform.position == puntoInicio.position)
                {
                    posObjetivo = puntoFinal.position;
                }
                else
                {
                    posObjetivo = puntoInicio.position;
                }
            }
        }
    }
}
