using UnityEngine;

namespace Battle
{
    public class TeamStore
    {
        private int numberOfTeams;
        private int currentTeam;
        
        public void SetNumberOfTeams(int teams)
        {
            numberOfTeams = teams;
        }

        public void SetCurrentTeam(int teamIndex)
        {
            currentTeam = teamIndex;
        }

        public int GetCurrentTeam()
        {
            return currentTeam;
        }
    }
}