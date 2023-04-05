using Snake.Domain.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Domain.Repositories.Abstract
{
    public interface IGameRepositories: IRepositories<Game>
    {
        ICollection<Game> Get();
    }
    
}
