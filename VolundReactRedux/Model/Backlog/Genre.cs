﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolundApp.Model.Backlog
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Game> GamesInGenre { get; set; }
    }
}
