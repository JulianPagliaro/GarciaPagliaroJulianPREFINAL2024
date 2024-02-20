using FinalProgramacion2023.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProgramacion2023.Datos
{
    public class RepositorioDeCuadrilatero 
    { 
    private readonly string _archivo = Environment.CurrentDirectory + "//Cuadrilateros.txt";
    private readonly string _archivoCopia = Environment.CurrentDirectory + "//Cuadrilateros.bak";

    private List<Cuadrilatero> listaCuadrilatero;
    public RepositorioDeCuadrilatero()
    {
        listaCuadrilatero = new List<Cuadrilatero>();
        LeerDatos();
    }

    private void LeerDatos()
    {
        listaCuadrilatero.Clear();
        if (File.Exists(_archivo))
        {
            var lector = new StreamReader(_archivo);
            while (!lector.EndOfStream)
            {
                string lineaLeida = lector.ReadLine();
                Cuadrilatero cuadrilatero = ConstruirCuadrilatero(lineaLeida);
                listaCuadrilatero.Add(cuadrilatero);
            }
            lector.Close();
        }
    }

    public void Editar(Cuadrilatero cuadrilateroViejo, Cuadrilatero cuadrilateroEditar)
    {
        using (var lector = new StreamReader(_archivo))
        {
            using (var escritor = new StreamWriter(_archivoCopia))
            {
                while (!lector.EndOfStream)
                {
                    string lineaLeida = lector.ReadLine();
                    Cuadrilatero cuadrilatero = ConstruirCuadrilatero(lineaLeida);
                    if (cuadrilatero.GetLadoA() == cuadrilateroViejo.GetLadoA() &&
                        cuadrilatero.GetLadoB() == cuadrilateroViejo.GetLadoB() &&
                        cuadrilatero.TipoDeBorde.GetHashCode() == cuadrilateroViejo.TipoDeBorde.GetHashCode() &&
                        cuadrilatero.ColorRelleno.GetHashCode() == cuadrilateroViejo.ColorRelleno.GetHashCode())
                    {
                        lineaLeida = ConstruirLinea(cuadrilateroEditar);
                        escritor.WriteLine(lineaLeida);
                    }
                    else
                    {
                        escritor.WriteLine(lineaLeida);

                    }
                }
            }
        }
        File.Delete(_archivo);
        File.Move(_archivoCopia, _archivo);
    }
    private Cuadrilatero ConstruirCuadrilatero(string lineaLeida)
    {

        var campos = lineaLeida.Split('|');
        int ladoA = int.Parse(campos[0]);
        int ladoB = int.Parse(campos[1]);
        Color color = (Color)Enum.Parse(typeof(Color), campos[2]);
        Borde borde = (Borde)Enum.Parse(typeof(Borde), campos[3]);
        Cuadrilatero cuadrilatero = new Cuadrilatero(ladoA, ladoB, color, borde);
        return cuadrilatero;
    }

    public void Agregar(Cuadrilatero cuadrilatero)
    {
        using (var escritor = new StreamWriter(_archivo, true))
        {
            string lineaEscribir = ConstruirLinea(cuadrilatero);
            escritor.WriteLine(lineaEscribir);
        }
        listaCuadrilatero.Add(cuadrilatero);
    }

        private string ConstruirLinea(Cuadrilatero cuadrilatero)
        {
            return $"{cuadrilatero.GetLadoA()}|" +
                   $"{cuadrilatero.GetLadoB()}|"+
                   $"{cuadrilatero.ColorRelleno.GetHashCode()}|" +
                   $"{cuadrilatero.TipoDeBorde.GetHashCode()}";
    }

    public int GetCantidad(int? valorFiltro = 0)
    {
        if (valorFiltro > 0)
        {
            return listaCuadrilatero.Count(c => c.LadoA > valorFiltro);
        }
        return listaCuadrilatero.Count();
    }

    public void Borrar(Cuadrilatero cuadrilateroBorrar)
    {
        using (var lector = new StreamReader(_archivo))
        {
            using (var escritor = new StreamWriter(_archivoCopia))
            {
                while (!lector.EndOfStream)
                {
                    string lineaLeida = lector.ReadLine();
                    Cuadrilatero cuadrilateroLeido = ConstruirCuadrilatero(lineaLeida);
                    if (cuadrilateroBorrar.GetLadoA() != cuadrilateroLeido.GetLadoB())
                    {
                        escritor.WriteLine(lineaLeida);
                    }
                }
            }
        }
        File.Delete(_archivo);
        File.Move(_archivoCopia, _archivo);
        listaCuadrilatero.Remove(cuadrilateroBorrar);
    }
    public List<Cuadrilatero> GetLista()
    {
        LeerDatos();
        return listaCuadrilatero;
    }

    public List<Cuadrilatero> Filtrar(int valorFiltro)
    {
        return listaCuadrilatero.Where(l => l.ColorRelleno.GetHashCode() == valorFiltro).ToList();
    }

    public bool Existe(Cuadrilatero cuadrilatero)
    {
        listaCuadrilatero.Clear();
        LeerDatos();
        bool existe = false;
        foreach (var itemCuadrilatero in listaCuadrilatero)
        {
            if (itemCuadrilatero.GetLadoA() == cuadrilatero.GetLadoA() &&
                itemCuadrilatero.GetLadoB() == cuadrilatero.GetLadoB() &&
                itemCuadrilatero.TipoDeBorde == cuadrilatero.TipoDeBorde &&
                itemCuadrilatero.ColorRelleno == cuadrilatero.ColorRelleno)
            {
                return true;
            }
        }
        return false;
    }
}
}

