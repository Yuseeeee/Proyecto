using UnityEngine;

public class EleccionMejora : MonoBehaviour
{
    public GameObject panelOpciones;      
    private AtaquesJugador jugador;
    public int cantidadMejora = 10;

    void Start()
    {
        if (panelOpciones != null)
            panelOpciones.SetActive(false); 
    }

    public void MostrarOpciones(AtaquesJugador aj)
    {
        jugador = aj;
        if (panelOpciones != null)
            panelOpciones.SetActive(true);
    }

    public void ElegirPunio()
    {
    Debug.Log("ElegirPunio() ejecutado");
        if (jugador != null)
            jugador.MejorarPunio(cantidadMejora);

        if (panelOpciones != null)
            panelOpciones.SetActive(false);
    }


    public void ElegirPatada()
    {
        Debug.Log("ElegirPatada() ejecutado");
        if (jugador != null)
            jugador.MejorarPatada(cantidadMejora);

        if (panelOpciones != null)
            panelOpciones.SetActive(false);
    }
}
