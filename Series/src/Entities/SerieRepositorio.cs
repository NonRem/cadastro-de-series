﻿using Series.Interfaces;
using System.Collections.Generic;

namespace Series.Entities;

public class SerieRepositorio : IRepositorio<Serie>
{
    private List<Serie> listaSerie = new List<Serie>();
    
    public List<Serie> Lista()
    {
        return listaSerie;
    }

    public Serie RetornaPorId(int id)
    {
        return listaSerie[id];
    }

    public void Insere(Serie objeto)
    {
        listaSerie.Add(objeto);
    }

    public void Exclui(int id)
    {
        listaSerie[id].Excluir();
    }

    public void Atualiza(int id, Serie objeto)
    {
        listaSerie[id] = objeto;
    }

    public int ProximoId()
    {
        return listaSerie.Count;
    }
    
}