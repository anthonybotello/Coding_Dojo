from django.shortcuts import render, redirect, HttpResponse
from apps.wall.models import Post, Comment
from apps.login.models import User
from datetime import datetime, timedelta
from django.contrib import messages
import pytz

# Create your views here.
def wall(request):
    if not 'logged_in' in request.session:
        return redirect('/')

    context = {
        'user': User.objects.get(id=request.session['user_id']).first_name,
        'posts': Post.objects.all().order_by("-created_at"),
    }
    return render(request,'wall/wall.html',context)

def make_post(request):
    post_text = request.POST['post_text']
    post_poster = User.objects.get(id=int(request.POST['poster_id']))
    Post.objects.create(text=post_text,poster=post_poster)
    return redirect('/wall')

def post_comment(request):
    cmnt_text = request.POST['cmnt_text']
    cmnt_poster = User.objects.get(id=int(request.POST['poster_id']))
    cmnt_post = Post.objects.get(id=int(request.POST['post_id']))
    Comment.objects.create(text=cmnt_text,poster=cmnt_poster,message=cmnt_post)
    return redirect('/wall')

def delete_post(request):
    user_id = int(request.session['user_id'])
    poster_id = int(request.POST['poster_id'])
    post = Post.objects.get(id=int(request.POST['post_id']))
    request.session['post_id'] = post.id
    print(request.session['post_id'])
    if poster_id == user_id:
        if datetime.utcnow().replace(tzinfo=pytz.utc) - post.created_at < timedelta(minutes=30):
            post.delete()
        else:
            messages.error(request,"Can't delete posts older than 30 minutes.")
    else:
        messages.error(request,"Can't delete posts that aren't yours.")
    return redirect('/wall')

