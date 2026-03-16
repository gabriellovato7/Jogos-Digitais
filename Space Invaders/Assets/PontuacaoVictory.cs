using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExibirResultado : MonoBehaviour
{
    public TextMeshProUGUI textoPontosFinal;

    void Start()
    {
        if (PontuacaoManager.instancia != null)
        {
            int resultado = PontuacaoManager.instancia.pontosAtuais;
            textoPontosFinal.text = "PONTUAÇÃO: " + resultado.ToString();
            
            Destroy(PontuacaoManager.instancia.gameObject);
        }
    }
}
