from flask import Flask, render_template, request, redirect, session
import base64
from http import cookies
app = Flask(__name__)
app.secret_key = 'fnbW@@#)@  Gjwregnbovi3'

@app.route('/')
def show_counter():
    if 'views' in session:
        session['views'] += 1
    else:
        session['views'] = 1
    if 'count' in session:
        session['count'] += 1
    else:
        session['count'] = 1
    print(base64.urlsafe_b64decode('eyJjb3VudCI6MTAsInZpZXdzIjo0OH0==='))
    return render_template('counter.html')

@app.route('/destroy_session')
def destroy_session():
    session.clear()
    return redirect('/')

@app.route('/plus_two')
def plus_two():
    session['views'] -= 1
    session['count'] += 1
    return redirect('/')

@app.route('/reset')
def reset():
    session['views'] -= 1
    session.pop('count')
    return redirect('/')

@app.route('/custom_increment',methods=['POST'])
def custom_increment():
    session['views'] -= 1
    session['count'] += int(request.form['number']) - 1
    return redirect('/')

if __name__ == '__main__':
    app.run(debug=True)