using Snake.Domain.Models.Game;
using Snake.Domain.Repositories.Abstract;
using Snake.Logic.Models;

namespace Snake.Logic
{
    public class GameService
    {
        private IGameRepositories _gameRepository;
        public GameService(IGameRepositories gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public GameDTO Update(GameDTO gameDTO)
        {
            var newGame = new Game()
            {
                Id = gameDTO.Id,
                x1 = gameDTO.x1,
                y1 = gameDTO.y1,
                x2 = gameDTO.x2,
                y2 = gameDTO.y2,
            };
            _gameRepository.Update(newGame);
            return gameDTO;
        }
        public void Delete() {
            _gameRepository.Delete();
        }

        public GameGetAllCoordinateDTO GetCoordinate()
        {
            var result = new GameGetAllCoordinateDTO();
            result.Game = new List<GameDTO>();
            result.Game = _gameRepository.Get().Select(x => new GameDTO
            {
                Id = x.Id,
                x1 = x.x1,
                x2 = x.x2,
                y1 = x.y1,
                y2 = x.y2,
            }).ToList();
            return result;
        }
    }
}