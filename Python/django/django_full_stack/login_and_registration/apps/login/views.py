from django.shortcuts import render, redirect, HttpResponse
from .models import User
from django.contrib import messages
import bcrypt

# Create your views here.
def index(request):
    return render(request,'login/index.html')

def register(request):
    errors = User.objects.registration_validator(request.POST)
    if len(errors) > 0:
        for key,value in errors.items():
            messages.error(request,value,extra_tags="register")
        return redirect('/')
    
    else:
        User.objects.create(
            first_name=request.POST['first_name'],
            last_name=request.POST['last_name'],
            birthday=request.POST['birthday'],
            email=request.POST['email'],
            password=bcrypt.hashpw(request.POST['password'].encode(),bcrypt.gensalt())
        )
        request.session['user'] = request.POST['first_name']
        request.session['logged_in'] = True
        return redirect('/success')

def login(request):
    errors,user_id = User.objects.login_validator(request.POST)
    if len(errors) > 0:
        for key,value in errors.items():
            messages.error(request,value,extra_tags="login")
        return redirect('/')

    else:
        request.session['user'] = User.objects.get(id=user_id).first_name
        request.session['logged_in'] = True
        return redirect('/success')

def success(request):
    if 'logged_in' in request.session: 
        context = {
            'user': ""
        }
        if 'user' in request.session:
            context['user'] = ", "+ request.session['user']
        return render(request,'login/success.html',context)
    else:
        return redirect('/')

def logout(request):
    request.session.clear()
    print(request.session)
    return redirect('/')