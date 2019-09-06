from django.shortcuts import render, redirect, HttpResponse
from .models import Show
from datetime import date, datetime

# Create your views here.
def index(request):
    return redirect('/shows')

def shows(request):
    context = {
        'shows': Show.objects.all()
    }
    return render(request, 'tv_shows_app/shows.html',context)

def new_show(request):
    context = {
        'today': date.today().isoformat()
    }
    return render(request, 'tv_shows_app/new_show.html',context)

def add_show(request):
    request.session['errors'] = Show.objects.validator(request.POST)
    if len(request.session['errors']) > 0:
        return redirect ('/shows/new')
    else:
        Show.objects.create(
            title=request.POST['title'],
            network=request.POST['network'],
            release_date=request.POST['release_date'],
            description=request.POST['description']
            )
        new_id = Show.objects.last().id
        return redirect(f'/shows/{new_id}')

def show_info(request,num):
    context = {
        'show': Show.objects.get(id=int(num))
    }
    return render(request,'tv_shows_app/show_info.html',context)

def destroy(request,num):
    Show.objects.get(id=int(num)).delete()
    return redirect('/shows')

def edit_show(request,num):
    context = {
        'show': Show.objects.get(id=int(num)),
        'date': Show.objects.get(id=int(num)).release_date.isoformat()
    }
    return render(request,'tv_shows_app/edit_show.html',context)

def process_edit(request):
    request.session['errors'] = Show.objects.validator(request.POST)
    if len(request.session['errors']) > 0:
        return redirect (f'/shows/{request.POST["show_id"]}/edit')
    else:
        edited_show = Show.objects.get(id=request.POST['show_id'])
        edited_show.title = request.POST['title']
        edited_show.network = request.POST['network']
        edited_show.release_date = request.POST['release_date']
        edited_show.description = request.POST['description']
        edited_show.save()
        return redirect('/shows')