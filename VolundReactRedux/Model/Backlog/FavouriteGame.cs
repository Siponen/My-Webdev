using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VolundApp.Model.Backlog;

namespace VolundApp.Model.Backlog
{
    public class FavouriteGame
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
