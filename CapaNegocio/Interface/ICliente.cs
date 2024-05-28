using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data; //Usar los buffer de memoria
using CapaEntidad;

namespace CapaNegocio.Interface
{
    interface ICliente
    {
        //Declarar los metodos de la clase cliente de la capa de negocios
        DataTable Listar();
        bool Agregar(Cliente cliente);
        bool Eliminar(string codCliente);
        bool Actualizar(Cliente cliente);

        DataTable Buscar(string codCliente);
    }
}

