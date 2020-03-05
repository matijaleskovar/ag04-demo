using BusinessAccessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Models;
using DTO;
using DTO.Player.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DTO.Player.Request;
using BusinessAccessLayer.Helpers;

namespace BusinessAccessLayer.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly DemoContext _context;

        public PlayerService(DemoContext context)
        {
            _context = context;
        }
        public PlayerSignInRespModel PlayerSignUp(PlayerSignInReqModel reqModel)
        {
            var result = new PlayerSignInRespModel();
            var entity = new Player();

            entity.Email = reqModel.Email;
            entity.Name = reqModel.Name;
            entity.CreatedUTC = DateTime.UtcNow;
            entity.ModifiedUTC = DateTime.UtcNow;

            if (_context.Players.Any(x => x.Email == reqModel.Email))
            {
                result.PlayerAlreadyExist = true;

                result.Error.ErrorArg = reqModel.Email;
                result.Error.ErrorCode = "error.username-already-taken";
            }
            else
            {
                _context.Players.Add(entity);
                _context.SaveChanges();

                result.PlayerId = entity.Id;
            }

            return result;
        }

        public PlayerProfileRespModel GetPlayerProfile(int id)
        {
            var result = new PlayerProfileRespModel();

            var player = _context.Players.FirstOrDefault(x => x.Id == id);

            if (player != null)
            {
                result.Id = player.Id;
                result.Email = player.Email;
                result.Name = player.Name;
            }
            else
            {
                result.Id = 0;
            }

            return result;
        }

        public List<PlayerProfileRespModel> GetAllPlayerProfiles()
        {
            var result = new List<PlayerProfileRespModel>();

            var playerList = _context.Players.ToList();

            if (playerList != null)
            {
                foreach (var item in playerList)
                {
                    var player = new PlayerProfileRespModel();

                    player.Id = item.Id;
                    player.Email = item.Email;
                    player.Name = item.Name;

                    result.Add(player);
                }
            }

            return result;
        }

        public PlayerChallengeRespModel ChallengePlayer(PlayerChallengeReqModel reqModel)
        {
            var result = new PlayerChallengeRespModel();

            var game = new Game();
            var boardList = new List<Board>();
            List<PointCoordinate> pointCoordinateList;

            //Check if players exists
            if (_context.Players.Any(x => x.Id == reqModel.PlayerId) && _context.Players.Any(x => x.Id == reqModel.OpponentId))
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        //Create game
                        game.CreatedUTC = DateTime.UtcNow;
                        game.ModifiedUTC = DateTime.UtcNow;
                        game.PlayerId = reqModel.PlayerId;
                        game.OpponentId = reqModel.OpponentId;
                        game.GameStatusId = (int)Enums.GameStatus.InProgress;

                        _context.Add(game);
                        _context.SaveChanges();

                        //Create boards
                        boardList.Add(new Board()
                        {
                            CreatedUTC = DateTime.UtcNow,
                            ModifiedUTC = DateTime.UtcNow,
                            PlayerId = reqModel.PlayerId,
                            GameId = game.Id
                        });

                        boardList.Add(new Board()
                        {
                            CreatedUTC = DateTime.UtcNow,
                            ModifiedUTC = DateTime.UtcNow,
                            PlayerId = reqModel.OpponentId,
                            GameId = game.Id
                        });

                        foreach (var board in boardList)
                        {
                            _context.Add(board);
                        }

                        _context.SaveChanges();

                        //Create PointCoordinates
                        foreach (var board in boardList)
                        {
                            pointCoordinateList = SetRandomShipPoints(board.Id);

                            foreach (var point in pointCoordinateList)
                            {
                                _context.Add(point);
                            }
                        }

                        _context.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }

                    result.Data.PlayerId = reqModel.PlayerId;
                    result.Data.OpponentId = reqModel.OpponentId;
                    result.Data.GameId = game.Id;
                    result.Data.StartingPlayer = RandomStartPlayer(reqModel.PlayerId, reqModel.OpponentId);
                }
            }
            else
            {
                result.Error.ErrorArg = reqModel.PlayerId.ToString();
                result.Error.ErrorCode = "error.unknown-user-id";
            }

            return result;
        }

        //Mock algorithm, just for demo purpose to fill some random data
        private List<PointCoordinate> SetRandomShipPoints(int boardId)
        {
            var result = new List<PointCoordinate>();

            for(int i = 1; i <= 4; i++)
            {
                result.Add(new PointCoordinate() 
                {
                    CreatedUTC = DateTime.UtcNow,
                    ModifiedUTC = DateTime.UtcNow,
                    BoardId = boardId,
                    AxisX = i,
                    AxisY = i,
                    Hit = false,
                    ShipTypeId = (int)Enums.ShipType.PatrolCraft
                });
            }

            return result;
        }

        private int RandomStartPlayer(int playerId1, int playerId2)
        {
            Random random = new Random();
            int number = random.Next(1, 10);

            if(number <= 5)
            {
                return playerId1;
            }
            else 
            {
                return playerId2;
            }
        }
    }
}
