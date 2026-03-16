using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontuacaoManager : MonoBehaviour
{
    public static PontuacaoManager instancia;
    
    public int pontosAtuais = 0; 

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AdicionarPontos(int valor)
    {
        pontosAtuais += valor;
    }
}
