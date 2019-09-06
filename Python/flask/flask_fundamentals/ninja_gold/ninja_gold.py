from flask import Flask, render_template, request, redirect, session
import datetime, random

app = Flask(__name__)
app.secret_key = "NINJA GAME SECRET KEY"

@app.route('/')
def index():
    if 'count' not in session:
        session['count'] = 0
    if 'your_gold' not in session:
        session['your_gold'] = 0
    print(session['count'])
    print(session['your_gold'])
    if 'history' not in session:
        session['history'] = [f'Started playing! ({datetime.datetime.now().strftime("%Y/%m/%d %I:%M %p")})']
    print(datetime.datetime.now().strftime("%Y/%m/%d %I:%M %p"))
    return render_template('ninja_gold.html')

@app.route('/process_money',methods=['POST'])
def process_money():
    if request.form['building'] == 'farm':
        delta_gold = random.randint(10,20)
        session['your_gold'] += delta_gold
        session['history'].append(f'Earned {delta_gold} golds from the farm! ({datetime.datetime.now().strftime("%Y/%m/%d %I:%M %p")})')
    
    if request.form['building'] == 'cave':
        delta_gold = random.randint(5,10)
        session['your_gold'] += delta_gold
        session['history'].append(f'Earned {delta_gold} golds from the cave! ({datetime.datetime.now().strftime("%Y/%m/%d %I:%M %p")})')

    if request.form['building'] == 'house':
        delta_gold = random.randint(2,5)
        session['your_gold'] += delta_gold
        session['history'].append(f'Earned {delta_gold} golds from the house! ({datetime.datetime.now().strftime("%Y/%m/%d %I:%M %p")})')

    if request.form['building'] == 'casino':
        delta_gold = random.randint(0,50)*(-1)**random.randint(1,2)
        session['your_gold'] += delta_gold
        if delta_gold >= 0:
            session['history'].append(f'Entered a casino and earned {delta_gold} golds! ({datetime.datetime.now().strftime("%Y/%m/%d %I:%M %p")})')
        else:
            session['history'].append(f'Entered a casino and lost {delta_gold*(-1)} golds... Ouch... ({datetime.datetime.now().strftime("%Y/%m/%d %I:%M %p")})')
    session['count'] += 1
    return redirect('/')

@app.route('/clear_session')
def clear_session():
    session.clear()
    return redirect('/')



if __name__ == '__main__':
    app.run(debug=True)