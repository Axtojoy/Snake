using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Domain.Repositories.Abstract
{
    public interface IRepositories<Game>
    {
        public void Update(Game game);

        public void Delete();


    }
}
