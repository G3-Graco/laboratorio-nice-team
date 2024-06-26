using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Interfaces.Repositorios
{
    public interface IPlazoRepositorio : IBaseRepositorio<Plazo>
    {
		ValueTask<Plazo> ConsultarPlazoIdeal(int nroCuotasDeseada);
		ValueTask<int> ConsultarPlazoMinimo();
		ValueTask<int> ConsultarPlazoMaximo();
	}
}