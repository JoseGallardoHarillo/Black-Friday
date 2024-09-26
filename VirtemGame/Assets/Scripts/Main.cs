using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    //private Vector3 OldMousePosition;
    
    //private Vector3 MouseDelta;
    private GameObject ClickedObject=null;
    private Rigidbody RB;
    //public int distance = 1;
    public GameObject Capsula;

    //Atributos nuevos

    private Vector3 mOffset;
    private float mz;
    private Collider collider;
    public bool inminigame = false;

    [SerializeField] CameraUI cameraManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

// Update is called once per frame
    void Update()
    {
        // Manejar clics del ratón
        if (Input.GetMouseButtonDown(0)) // Al pulsar el botón izquierdo del ratón
        {
            // Lanzar un rayo desde la cámara en la dirección del ratón
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Verificar si el rayo golpea un objeto en el entorno
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    // Llamada a método para manejar el objeto clicado
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }
        else if (Input.GetMouseButton(0))
        {
            // Si se mantiene presionado, manejar el objeto clicado
            if (ClickedObject != null)
            {
                handleClickedGameObject(ClickedObject);
            }
        }
        else
        {
            ClickedObject = null;
        }
    }

    // Método para manejar el objeto clicado inicialmente
    public void CurrentClickedGameObject(GameObject gameObject)
    {
        ClickedObject = gameObject;

        // Realizar acciones específicas según la etiqueta del objeto
        if (gameObject.tag == "Capsula")
        {

            mz = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseWorldPos();
        } else if (gameObject.tag == "Ordenador") {
            cameraManager.PasaraUI();
        }
    }

    // Método para manejar el objeto durante el clic sostenido
    public void handleClickedGameObject(GameObject gameObject)
    {
        if (gameObject.tag == "Capsula")
        {
                collider = gameObject.GetComponent<Collider>();
                Vector3 desiredPosition = GetMouseWorldPos() + mOffset;
                bool canMove = true;

                if (Physics.CheckBox(desiredPosition + gameObject.transform.position, collider.bounds.extents))
                {
                    canMove = false;
                }

                if (canMove)
                {
                gameObject.transform.position = desiredPosition;
                }
        }
        else if (gameObject.tag == "Caja")
        {
            gameObject.tag = "Untagged";
            Object.Destroy(gameObject);
            TipoCapsula aux = gameObject.GetComponent<TipoCapsula>();
            Instantiate(GameObject.Find(aux.Tipo), gameObject.transform.position, gameObject.transform.rotation);
            // Ejemplo: Instanciar una nueva cápsula y destruir la caja original
            GameManager.Instance.AddScore(aux.basePrice);
            gameObject = null;
        }
    }

    private Vector3 GetMouseWorldPos(){
        Vector3 MousePosition = Input.mousePosition;
        MousePosition.z = mz;

        return Camera.main.ScreenToWorldPoint(MousePosition);
    }
}