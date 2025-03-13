using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using Entidades = CapaEntidades;

namespace CapaAplicacion
{
    public class AppParticipante
    {
        private static readonly AppParticipante _instancia = new AppParticipante();

        public static AppParticipante Instancia
        {
            get
            {
                return _instancia;
            }
        }

        private AppParticipante() { }

        public List<Entidades.Participante> ListarParticipantes()
        {
            return DatParticipante.Instancia.ListarParticipantes();
        }

        public bool InsertarParticipante(Entidades.Participante participante)
        {
            return DatParticipante.Instancia.InsertarParticipante(participante);
        }

        public bool EliminarParticipante(int idParticipante)
        {
            return DatParticipante.Instancia.EliminarParticipante(idParticipante);
        }
    }
}
