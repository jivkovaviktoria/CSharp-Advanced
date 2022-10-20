using System;

namespace Basketball
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Team
    {
        public Team(string name, int openPositions, char group)
        {
            this.players = new List<Player>();
            this.Name = name;
            this.OpenPositions = openPositions;
            this.Group = group;
        }

        private readonly List<Player> players;
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }

        public int Count => this.players.Count;

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position)) return "Invalid player's information.";
            if (this.OpenPositions == 0) return "There are no more open positions.";
            if (player.Rating < 80) return "Invalid player's rating.";

            this.players.Add(player);
            this.OpenPositions--;
            return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            var playerToRemove = this.players.Find(x => x.Name == name);
            if (playerToRemove == null) return false;

            this.players.Remove(playerToRemove);
            this.OpenPositions++;
            return true;
        }

        public int RemovePlayerByPosition(string position)
        {
            var playersToRemove = this.players.FindAll(x => x.Position == position);
            foreach (var player in playersToRemove) this.players.Remove(player);

            this.OpenPositions += playersToRemove.Count;
            return playersToRemove.Count;
        }

        public Player RetirePlayer(string name)
        {
            var playerToRetire = this.players.Find(x => x.Name == name);
            if (playerToRetire == null) return null;

            playerToRetire.Retired = true;
            return playerToRetire;
        }

        public List<Player> AwardPlayers(int games)
        {
            var playersToAward = this.players.Where(x => x.Games >= games).ToList();
            return playersToAward;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");

            foreach (var player in this.players.Where(x => x.Retired == false))
                sb.AppendLine(player.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}