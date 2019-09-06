from django.shortcuts import render, redirect
from datetime import datetime
from random import randint

# Create your views here.
def index(request):
    if 'gold' not in request.session:
        request.session['gold'] = 0
    if 'history' not in request.session:
        request.session['history'] = [f'Started playing! ({datetime.now().strftime("%Y/%m/%d %I:%M %p")})']
    return render(request,'ninja_gold_app/index.html')

def process_money(request):
    if request.POST['building'] == 'farm':
        delta_gold = randint(10,20)
        request.session['gold'] += delta_gold
        request.session['history'].append(f'Earned {delta_gold} golds from the farm! ({datetime.now().strftime("%Y/%m/%d %I:%M %p")})')
    if request.POST['building'] == 'cave':
        delta_gold = randint(5,10)
        request.session['gold'] += delta_gold
        request.session['history'].append(f'Earned {delta_gold} golds from the cave! ({datetime.now().strftime("%Y/%m/%d %I:%M %p")})')
    if request.POST['building'] == 'house':
        delta_gold = randint(2,5)
        request.session['gold'] += delta_gold
        request.session['history'].append(f'Earned {delta_gold} golds from the house! ({datetime.now().strftime("%Y/%m/%d %I:%M %p")})')
    if request.POST['building'] == 'casino':
        delta_gold = randint(-50,50)
        request.session['gold'] += delta_gold
        if delta_gold >= 0:
            request.session['history'].append(f'Entered a casino and earned {delta_gold} golds! ({datetime.now().strftime("%Y/%m/%d %I:%M %p")})')
        else:
            request.session['history'].append(f'Entered a casino and lost {delta_gold*(-1)} golds... Ouch... ({datetime.now().strftime("%Y/%m/%d %I:%M %p")})')
    return redirect('/')

def restart(request):
    del request.session['gold']
    del request.session['history']
    return redirect('/')