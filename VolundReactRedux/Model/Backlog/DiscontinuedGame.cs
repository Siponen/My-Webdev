using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VolundApp.Model.Backlog
{
    public class DiscontinuedGame
    {
        public int Id { get; set; }
        public string Comment { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
