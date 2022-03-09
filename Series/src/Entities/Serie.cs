using Series.Enum;

namespace Series.Entities;

public class Serie : EntidadeBase
{
    public Genero Genero { get; set; }

    public string Titulo { get; set; }

    public string Descricao{ get; set; }

    public int Ano{ get; set; }
    
    private bool Excluido { get; set;}

    public Serie(int id,Genero genero, string titulo, string descricao, int ano)
    {
        this.Id = id;
        this.Genero = genero;
        this.Titulo = titulo;
        this.Descricao = descricao;
        this.Ano = ano;
        this.Excluido = false;
    }

    public override string ToString()
    {
        var retorno = "";
        retorno += "Gênero: " +this.Genero + Environment.NewLine;
        retorno += "Título: " +this.Titulo + Environment.NewLine;
        retorno += "Descrição: " +this.Descricao + Environment.NewLine;
        retorno += "Ano: " +this.Ano+ Environment.NewLine;
        return retorno;
    }

    public string RetornaTitulo()
    {
        return this.Titulo;
    }

    public int RetornaId()
    {
        return this.Id;
    }

    public void Excluir()
    {
        this.Excluido = true;
    }

    public bool RetornaExcluido()
    {
        return Excluido;
    }
}