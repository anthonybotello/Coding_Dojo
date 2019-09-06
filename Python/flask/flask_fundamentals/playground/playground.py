from flask import Flask, render_template, redirect
app = Flask(__name__)


@app.route('/')
def welcome():
    return redirect('/play')

@app.route('/play')
def play():
    return render_template("play.html",box_times=3,box_color='#9fc5f8')

@app.route('/play/<x>')
def box_times(x):
    return render_template('play.html',box_times=int(x),box_color='#9fc5f8')

@app.route('/play/<x>/<color>')
def box_color(x,color):
    return render_template('play.html',box_times=int(x),box_color=color)

if __name__ == '__main__':
    app.run(debug=True)