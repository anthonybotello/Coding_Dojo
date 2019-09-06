from flask import Flask, render_template, request, redirect, session
import random

app = Flask(__name__)
app.secret_key = 'jdsfh$mi3m923$)I#mb'

@app.route('/')
def great_number_game():
    guess_status = 'None'
    if 'number' not in session:
        session['number'] = random.randint(1,100)
    print(session['number'])
    if 'guess' in session:
        if int(session['guess']) < session['number']:
            guess_status = 'low'
        if int(session['guess']) > session['number']:
            guess_status = 'high'
        if int(session['guess']) == session['number']:
            guess_status = 'correct' 
    return render_template('great_number_game.html',guess=guess_status)

@app.route('/process_guess',methods=['POST'])
def process_guess():
    if 'count' in session:
        session['count'] += 1
    else:
        session['count'] = 1
    print(f"attempt #{session['count']}")
    session['guess'] = request.form['guess']
    return redirect('/')

@app.route('/play_again')
def play_again():
    session.pop('guess')
    session.pop('count')
    session.pop('number')
    return redirect('/')

#Finish later
# @app.route('/process_winner',)
# def create_winner():
#     session[request.form['name']] = session['count']
#     return redirect('/leaderboard')
# @app.route('/leaderboard')


if __name__ == '__main__':
    app.run(debug=True)