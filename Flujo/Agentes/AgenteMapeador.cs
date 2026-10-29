using Abstracciones.Agentes;
using Abstracciones.Clientes;
using System;
using System.Collections.Generic;
using System.Text;
using static Abstracciones.Agentes.AgenteActualizarDto;

namespace Flujo.Agentes
{
    internal class AgenteMapeador
    {
        public static AgenteDto ADto(Agente a) =>
       new(a.ID, a.Nombre, a.Correo, a.Telefono, a.CapacidadMaxima, a.Estado, a.FechaIngreso);
    }
}
