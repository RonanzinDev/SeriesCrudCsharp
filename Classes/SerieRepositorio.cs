using System.Collections.Generic;

namespace exer
{
    public class SerieRepositorio : IRepositorio<Series>
    {
        private List<Series> listSeries = new List<Series>();
        public void Atualiza(int id, Series entidade)
        {
            listSeries[id] = entidade;
        }

        public void Exclui(int id)
        {
            listSeries[id].Excluir();
        }

        public void Inserte(Series entidade)
        {
            listSeries.Add(entidade);
        }

        public List<Series> Lista()
        {
            return listSeries;
        }

        public int ProximoId()
        {
            return listSeries.Count;
        }

        public Series RetornaPorId(int id)
        {
            return listSeries[id];
        }
    }
}