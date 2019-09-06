from django.shortcuts import render, redirect
from .models import League, Team, Player
from django.db.models import Count

from . import team_maker

def index(request):
	context = {
		"leagues": League.objects.filter(teams__curr_players__first_name__iexact="Sophia"),
		"teams": Team.objects.annotate(Count('all_players')).filter(all_players__count__gt=12),
		"players": Player.objects.annotate(Count('all_teams')).order_by("all_teams__count")
	}
	return render(request, "leagues/index.html", context)

def make_data(request):
	team_maker.gen_leagues(10)
	team_maker.gen_teams(50)
	team_maker.gen_players(200)

	return redirect("index")