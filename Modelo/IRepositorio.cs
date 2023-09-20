using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public interface IRepositorio<T>
    {
        IReadOnlyList<T> Recuperar();
        bool Crear(T item);
        bool Modificar(T item);
        bool Eliminar(T item);
    }
}
