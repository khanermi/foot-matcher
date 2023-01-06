using ConsoleViewPresent;
using ConsoleViewPresent.Base;
using FootMatcher.Models.Models;
using FootMatcher.Presentation.ViewEventArgs;
using FootMatcher.Presentation.ViewInterfaces;
using FootMatcher.Presentation.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Match = FootMatcher.Models.Models.Match;

namespace FootMatcher.ConsoleApp.Views.SessionDetails
{
    public class SessionDetailsView : View<SessionDetailsViewModel>, ISessionDetailsView
    {
        public SessionDetailsView(ConsoleViewRenderer renderer, SessionDetailsViewModel viewModel) : base(renderer, viewModel)
        {
        }

        public event EventHandler ExitToStartMenuEvent;

        public override void ConfigureComponents()
        {
            var components = new List<ConsoleRenderableComponent>()
            {
                ConfigureSessionDetailsComponent()
            };

            AddComponent(components);
        }

        private ConsoleRenderableComponent ConfigureSessionDetailsComponent()
        {
            var description = $"There is the list of matches to play:{Environment.NewLine}";

            var matches = ViewModel.Session.Matches.OrderBy(x => x.FirstPlayerTeam.HalfStarsCount);
            foreach (var match in matches)
            {
                description += BuildMatchLine(match);
            }

            var options = new List<Option>()
            {
                new Option("1", "Exit", "exitToStartMenu", OnExitToStartMenuEvent)
            };

            return new ConsoleRenderableComponent(description, options);
        }

        private string BuildMatchLine(Match match)
        {
            var matchLine = $"{BuildTeamString(match.FirstPlayerTeam)}".PadRight(3) + @"||\\\\\\\\\\|//////////||    " +
                $"{BuildTeamString(match.SecondPlayerTeam)}{Environment.NewLine}";

            return matchLine;
        }

        private string BuildTeamString(Team team)
        {
            var teamString = $"Country:".PadRight(10) + $"{team.CountryName}".PadRight(20) + "|".PadRight(2) +
                $"League:".PadRight(9) + $"{team.LeagueName}".PadRight(20) + "|".PadRight(2) +
                $"Team:".PadRight(7) + $"{team.Name}".PadRight(30);
                //+ $"Rating:".PadRight(8) + $"{team.HalfStarsCount * 0.5}*".PadRight(6);

            return teamString;
        }

        private void OnExitToStartMenuEvent(object sender, EventArgs e)
        {
            if (e is not OptionSelectedEventArgs eventArgs)
            {
                throw new InvalidCastException(nameof(OptionSelectedEventArgs));
            }

            ExitToStartMenuEvent?.Invoke(this, new ExitToStartMenuEventArgs());
        }

        public void SetExitToStartMenuEventHandler(EventHandler eventHandler)
        {
            ExitToStartMenuEvent = eventHandler;
        }
    }
}
