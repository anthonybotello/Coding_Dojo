from django.shortcuts import render, redirect
from django.utils.crypto import get_random_string

# Create your views here.
def index(request):
    return redirect('/random_word')

def random_word(request):
    context = {
        'r_word':get_random_string(length=14)
    }
    if 'counter' not in request.session:
        request.session['counter'] = 1
    else:
        request.session['counter'] += 1
    return render(request,'random_word/random_word.html',context)

def reset(request):
    del request.session['counter']
    return redirect('/')