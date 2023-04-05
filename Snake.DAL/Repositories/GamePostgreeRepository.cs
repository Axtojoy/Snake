using Snake.Domain.Models.Game;
using Snake.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.DAL.Repositories
{
    public class GamePostgreeRepository : IGameRepositories, IRepositories<Game>
    {
        private readonly PostgreeContext _postgreeContext;

        public GamePostgreeRepository(PostgreeContext postgreeContext)
        {
            _postgreeContext = postgreeContext;
        }
        public void Delete()
        {
            _postgreeContext.Game.RemoveRange(_postgreeContext.Game);
            _postgreeContext.SaveChanges();
        }


        public void Update(Game game)
        {
            _postgreeContext.Update(game);
            _postgreeContext.SaveChanges();
        }

        ICollection<Game> IGameRepositories.Get()
        {
            var game = _postgreeContext.Game.ToList();
            return game;
        }
    }
}
