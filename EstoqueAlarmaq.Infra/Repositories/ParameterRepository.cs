using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Data;
using EstoqueAlarmaq.Infra.Interfaces;
using EstoqueAlarmaq.Infra.Repositories.Generic;

namespace EstoqueAlarmaq.Infra.Repositories
{
    public class ParameterRepository : GenericRepository<Parameter>, IParameterRepository
    {
        public ParameterRepository(DataContext dataContext) : base(dataContext)
        {
                
        }
    }
}
